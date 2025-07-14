using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuScript : MonoBehaviour
{
    public GameObject panelButtons;
    public Button menuButton;
    public Button exercisesBtn;
    public Button HealthyEatingBtn;

    void start() {
        menuButton.onClick.AddListener(OpenOptionsPanel);
    }

    public void OpenOptionsPanel() {
        panelButtons.SetActive(true);
    }

}
