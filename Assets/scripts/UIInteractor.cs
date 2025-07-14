using UnityEngine;
using UnityEngine.UI;

public class PersonInteraction : MonoBehaviour
{
    public GameObject uiPanel; // Assign the UI panel in the Inspector

    void Start()
    {
        if (uiPanel != null)
        {
            uiPanel.SetActive(false); // Ensure the UI panel is initially inactive
        }
        else
        {
            Debug.LogError("UI Panel not assigned in the Inspector.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger zone.");
            if (uiPanel != null)
            {
                uiPanel.SetActive(true); // Show the UI panel
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited the trigger zone.");
            if (uiPanel != null)
            {
                uiPanel.SetActive(false); // Hide the UI panel
            }
        }
    }
}
