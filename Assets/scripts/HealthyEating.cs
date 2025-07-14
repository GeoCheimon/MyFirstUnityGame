using UnityEngine;
using UnityEngine.UI;

public class HealthyEating : MonoBehaviour
{
    // References to the panels
    public GameObject firstLayerPanel;
    public GameObject secondLayerPanel;
    public GameObject thirdLayerPanel;
    public GameObject fourthLayerPanel;
    public GameObject fifthLayerPanel;

    // References to the buttons
    public Button firstLayerButton;
    public Button secondLayerButton;
    public Button thirdLayerButton;
    public Button fourthLayerButton;
    public Button fifthLayerButton;

    void Start()
    {
        // Ensure all panels are inactive at the start
        firstLayerPanel.SetActive(false);
        secondLayerPanel.SetActive(false);
        thirdLayerPanel.SetActive(false);
        fourthLayerPanel.SetActive(false);
        fifthLayerPanel.SetActive(false);

        // Add listeners to the buttons
        firstLayerButton.onClick.AddListener(OpenFirstLayerPanel);
        secondLayerButton.onClick.AddListener(OpenSecondLayerPanel);
        thirdLayerButton.onClick.AddListener(OpenThirdLayerPanel);
        fourthLayerButton.onClick.AddListener(OpenFourthLayerPanel);
        fifthLayerButton.onClick.AddListener(OpenFifthLayerPanel);
    }

    public void OpenFirstLayerPanel()
    {
        CloseAllPanels();
        firstLayerPanel.SetActive(true);
    }

    public void OpenSecondLayerPanel()
    {
        CloseAllPanels();
        secondLayerPanel.SetActive(true);
    }

    public void OpenThirdLayerPanel()
    {
        CloseAllPanels();
        thirdLayerPanel.SetActive(true);
    }

    public void OpenFourthLayerPanel()
    {
        CloseAllPanels();
        fourthLayerPanel.SetActive(true);
    }

    public void OpenFifthLayerPanel()
    {
        CloseAllPanels();
        fifthLayerPanel.SetActive(true);
    }

    private void CloseAllPanels()
    {
        firstLayerPanel.SetActive(false);
        secondLayerPanel.SetActive(false);
        thirdLayerPanel.SetActive(false);
        fourthLayerPanel.SetActive(false);
        fifthLayerPanel.SetActive(false);
    }
}
