using UnityEngine;

public class OpenPuzzle : MonoBehaviour
{
    public GameObject puzzleCanvas;
    public float interactDistance = 3f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            
            Ray ray = new(Camera.main.transform.position, Camera.main.transform.forward);

            if (Physics.Raycast(ray, out RaycastHit hit, interactDistance))
            {
                if (hit.collider.CompareTag("PuzzleTrigger"))
                {
                    puzzleCanvas.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    Time.timeScale = 0;
                }
            }
        }
    }
}
