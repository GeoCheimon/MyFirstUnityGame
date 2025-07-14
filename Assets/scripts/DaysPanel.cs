using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DaysPanel : MonoBehaviour
{
    public List<GameObject> dayPanels; // List of all day panels
    private GameObject currentPanel; // Track the currently active panel

    public void TogglePanel(GameObject panelToToggle)
    {
        if (panelToToggle != null)
        {
            CloseCurrentPanel(); // Close the currently active panel
            panelToToggle.SetActive(true); // Open the specified panel
            currentPanel = panelToToggle; // Update the currently active panel
        }
    }

    private void CloseCurrentPanel()
    {
        if (currentPanel != null && currentPanel.activeSelf)
        {
            currentPanel.SetActive(false);
        }
    }
}
