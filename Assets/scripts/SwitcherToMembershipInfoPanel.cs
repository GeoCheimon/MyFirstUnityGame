using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitcherToMembershipInfoPanel : MonoBehaviour
{
    public GameObject registrationFormPanel;  // Reference to the registration form panel
    public GameObject membershipPanel;        // Reference to the membership panel
    public Button membershipButton;
    public Button backToRegistrationBtn;
    
    void Start() {
        membershipPanel.SetActive(false);

        membershipButton.onClick.AddListener(OpenMembershipPanel);
        backToRegistrationBtn.onClick.AddListener(BackToRegistrationForm);
    }
    
    // Method to open the membership panel
    public void OpenMembershipPanel()
    {
        membershipPanel.SetActive(true);
    }

    // Method to go back to the registration form panel
    public void BackToRegistrationForm()
    {
        membershipPanel.SetActive(false);        // Hide the membership panel
        registrationFormPanel.SetActive(true);   // Show the registration form panel
    }
}
