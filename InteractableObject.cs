using System.Collections;
using System.Collections.Generic;
using UnityEngine;



 

public class InteractableObject : MonoBehaviour
{
    [Header("Interaction")]
    public string promptMessage = "Press E to interact";
    public GameObject puzzlePanel;

    [Header("Player Reference")]
    public GameObject player;

    private bool isPanelOpen = false;

    public void Interact()
    {
        if (puzzlePanel != null)
        {
            isPanelOpen = !isPanelOpen;
            puzzlePanel.SetActive(isPanelOpen);

            if (isPanelOpen)
            {
                Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Time.timeScale = 1f;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }

    public void ClosePanel()
    {
        if (puzzlePanel != null)
        {
            puzzlePanel.SetActive(false);
            isPanelOpen = false;
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}

