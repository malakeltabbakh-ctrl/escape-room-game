using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class PlayerInteract : MonoBehaviour
{
    [Header("Interaction Settings")]
    public float interactDistance = 3f;
    public KeyCode interactKey = KeyCode.E;
    public LayerMask interactableLayer;

    [Header("UI References")]
    public GameObject interactPrompt;
    public Text promptText;

    private Camera playerCamera;
    private InteractableObject currentInteractable;

    void Start()
    {
        playerCamera = GetComponentInChildren<Camera>();
        if (interactPrompt != null)
            interactPrompt.SetActive(false);
    }

    void Update()
    {
        CheckForInteractable();

        if (Input.GetKeyDown(interactKey) && currentInteractable != null)
        {
            currentInteractable.Interact();
        }
    }

    void CheckForInteractable()
    {
        RaycastHit hit;
        Ray ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));

        if (Physics.Raycast(ray, out hit, interactDistance, interactableLayer))
        {
            InteractableObject interactable = hit.collider.GetComponent<InteractableObject>();

            if (interactable != null)
            {
                currentInteractable = interactable;
                ShowPrompt(interactable.promptMessage);
                return;
            }
        }

        currentInteractable = null;
        HidePrompt();
    }

    void ShowPrompt(string message)
    {
        if (interactPrompt != null)
        {
            interactPrompt.SetActive(true);
            if (promptText != null)
                promptText.text = message;
        }
    }

    void HidePrompt()
    {
        if (interactPrompt != null)
            interactPrompt.SetActive(false);
    }
}
