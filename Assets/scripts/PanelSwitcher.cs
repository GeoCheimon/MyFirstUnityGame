using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelSwitcher : MonoBehaviour
{
    public GameObject npcPanel;  // The panel containing NPC and character dialogue
    public GameObject registrationFormPanel;  // The panel for the registration form

    // Call this method to open the registration form and hide the NPC panel
    public void OpenRegistrationForm()
    {
        if (npcPanel != null)
        {
            npcPanel.SetActive(false);  // Hide the NPC panel
        }
        if (registrationFormPanel != null)
        {
            registrationFormPanel.SetActive(true);  // Show the registration form panel
        }
    }

    // Optional: Call this method to close the registration form and show the NPC panel again
    public void CloseRegistrationForm()
    {
        if (registrationFormPanel != null)
        {
            registrationFormPanel.SetActive(false);  // Hide the registration form panel
        }
        if (npcPanel != null)
        {
            npcPanel.SetActive(true);  // Show the NPC panel
        }
    }
}
