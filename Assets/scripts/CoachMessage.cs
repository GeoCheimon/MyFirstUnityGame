using UnityEngine;
using UnityEngine.UI;

public class CoachMessage : MonoBehaviour
{
    public Exercises exercisesPanel;

    public void OnExerciseSelected(string exerciseName)
    {
        // Show the CoachPanel and play the exercise video
        exercisesPanel.PlayExercise(exerciseName);
    }
}
