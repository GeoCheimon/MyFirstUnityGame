using System.Collections.Generic;
using UnityEngine;

public class HelpPanelManager : MonoBehaviour
{
    public GameObject helpPanel; // The main help panel
    public GameObject completeBtn; // The complete button
    public List<GameObject> helpSections; // List of all help sections

    private int currentSectionIndex = 0;

    public void ShowHelp()
    {
        // Show the help panel and the complete button
        helpPanel.SetActive(true);
        completeBtn.SetActive(true);

        // Show the first help section and hide others
        ShowCurrentSection();
    }

    public void CompleteSection()
    {
        // Hide the current help section
        helpSections[currentSectionIndex].SetActive(false);

        // Move to the next section
        currentSectionIndex++;

        if (currentSectionIndex < helpSections.Count-1)
        {
            // Show the next help section
            ShowCurrentSection();
        }
        else
        {
            // Hide the help panel and complete button
            helpPanel.SetActive(false);
            completeBtn.SetActive(false);
            currentSectionIndex = 0; // Reset for next use
        }
    }

    private void ShowCurrentSection()
    {
        // Ensure only the current help section is shown
        for (int i = 0; i < helpSections.Count-1; i++)
        {
            helpSections[i].SetActive(i == currentSectionIndex);
        }
    }
}
