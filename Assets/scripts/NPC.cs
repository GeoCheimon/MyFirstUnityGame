using UnityEngine;

public class NPC : MonoBehaviour
{
    public Dialogue dialogue; // Reference to the dialogue data
    public GameObject newPanel;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Get the DialogueSystem instance and start the dialogue
            DialogueSystem dialogueSystem = FindObjectOfType<DialogueSystem>();
            if (dialogueSystem != null)
            {
                dialogueSystem.StartDialogue(dialogue, newPanel); // Pass the dialogue with names
            }
        }
    }
}
