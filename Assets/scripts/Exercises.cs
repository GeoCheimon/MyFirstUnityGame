using UnityEngine;
using UnityEngine.Video;

public class Exercises : MonoBehaviour
{
    public GameObject exercisesPanel;

    public GameObject squatsPanel;
    public GameObject absPanel;
    public GameObject pushUpsPanel;
    public GameObject lungePanel;
    public GameObject jumpingsPanel;

    private VideoPlayer videoPlayerSquats;
    private VideoPlayer videoPlayerAbs;
    private VideoPlayer videoPlayerPushUps;
    private VideoPlayer videoPlayerLunge;
    private VideoPlayer videoPlayerJumpings;

    void Start()
    {
        // Get VideoPlayer components from the panels
        videoPlayerSquats = squatsPanel.GetComponentInChildren<VideoPlayer>();
        videoPlayerAbs = absPanel.GetComponentInChildren<VideoPlayer>();
        videoPlayerPushUps = pushUpsPanel.GetComponentInChildren<VideoPlayer>();
        videoPlayerLunge = lungePanel.GetComponentInChildren<VideoPlayer>();
        videoPlayerJumpings = jumpingsPanel.GetComponentInChildren<VideoPlayer>();

        // Initialize panels to be inactive at start
        squatsPanel.SetActive(false);
        absPanel.SetActive(false);
        pushUpsPanel.SetActive(false);
        lungePanel.SetActive(false);
        jumpingsPanel.SetActive(false);

        // Disable the ExercisesPanel initially
        exercisesPanel.SetActive(false);
    }

    public void PlayExercise(string exerciseName)
    {
        // First, stop all videos
        StopAllVideos();

        // Enable the ExercisesPanel
        exercisesPanel.SetActive(true);

        switch (exerciseName)
        {
            case "Squats":
                squatsPanel.SetActive(true);
                videoPlayerSquats.Play();
                break;
            case "Abs":
                absPanel.SetActive(true);
                videoPlayerAbs.Play();
                break;
            case "PushUps":
                pushUpsPanel.SetActive(true);
                videoPlayerPushUps.Play();
                break;
            case "Lunge":
                lungePanel.SetActive(true);
                videoPlayerLunge.Play();
                break;
            case "Jumpings":
                jumpingsPanel.SetActive(true);
                videoPlayerJumpings.Play();
                break;
            default:
                Debug.LogError("Unknown exercise name: " + exerciseName);
                break;
        }
    }

    public void StopAllVideos()
    {
        // Deactivate all exercise panels
        squatsPanel.SetActive(false);
        absPanel.SetActive(false);
        pushUpsPanel.SetActive(false);
        lungePanel.SetActive(false);
        jumpingsPanel.SetActive(false);

        // Stop all video players
        videoPlayerSquats.Stop();
        videoPlayerAbs.Stop();
        videoPlayerPushUps.Stop();
        videoPlayerLunge.Stop();
        videoPlayerJumpings.Stop();
    }
}
