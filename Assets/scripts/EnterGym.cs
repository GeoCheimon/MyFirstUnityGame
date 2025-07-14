using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnterGym : MonoBehaviour
{

    public GameObject uiPanel;

    // Start is called before the first frame update
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ShowExercises() {
        SceneManager.LoadScene("ExercisesScene");
    }

    public void TrackProgress() {
        SceneManager.LoadScene("ProgressScene");
    }

    public void ShowHealthyEating() {
        SceneManager.LoadScene("HealthyEatingScene");
    }

    public void Store() {
        SceneManager.LoadScene("StoreScene");
    }

    public void TalkToTheCoach() {
        SceneManager.LoadScene("TalkToTheCoachScene");
    }

    public void TalkToTheNutritionist() {
        SceneManager.LoadScene("TalkToTheNutritionistScene");
    }

    public void GoBack(GameObject panel)
    {
        if (panel != null)
        {
            panel.SetActive(false); // Deactivate the panel
        }
    }

    public void ExitGame() {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_STANDALONE
            Application.Quit();
        #endif
    }
}
