using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public DoorScript.Door door;  // Reference to the Door script

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            door.OpenDoor();
        }
    }
}
