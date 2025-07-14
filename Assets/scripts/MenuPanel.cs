using UnityEngine;

public class SetActiveAlways : MonoBehaviour
{
    void Start()
    {
        // Ensure the GameObject this script is attached to remains active
        gameObject.SetActive(true);

        // Optionally, ensure the GameObject is not destroyed when loading new scenes
        // Don'tDestroyOnLoad(gameObject);
    }
}
