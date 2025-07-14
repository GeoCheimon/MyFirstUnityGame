using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public Text nameText;              // UI Text for the speaker's name
    public Text dialogueText;          // UI Text for the dialogue
    public GameObject dialoguePanel;   // Reference to the dialogue panel

    private Queue<string> speakerOneSentences;   
    private Queue<string> speakerTwoSentences;   

    private string speakerOneName;     
    private string playerName;          
    private GameObject initialPanel;    // The first panel opened by pressing "T"
    private Stack<GameObject> panelStack; // Stack to keep track of panel history

    void Start()
    {
        speakerOneSentences = new Queue<string>();
        speakerTwoSentences = new Queue<string>();
        panelStack = new Stack<GameObject>();
    }

    public void StartDialogue(Dialogue dialogue, GameObject panel)
    {
        dialoguePanel.SetActive(true);
        initialPanel = panel; // Set the initial panel reference

        speakerOneSentences.Clear();
        speakerTwoSentences.Clear();

        speakerOneName = dialogue.speakerOneName; // Set the name for Speaker One
        playerName = "You:"; // Set the name for Player

        foreach (string sentence in dialogue.speakerOneSentences)
        {
            speakerOneSentences.Enqueue(sentence);
        }

        foreach (string sentence in dialogue.speakerTwoSentences)
        {
            speakerTwoSentences.Enqueue(sentence);
        }

        // Start with Speaker One's turn
        if (speakerOneSentences.Count > 0)
        {
            DisplayNextSentence(true); // true for Speaker One's turn
        }
        else
        {
            EndDialogue(); // No sentences for Speaker One
        }
    }

    public void DisplayNextSentence(bool isSpeakerOneTurn)
    {
        if (isSpeakerOneTurn)
        {
            if (speakerOneSentences.Count > 0)
            {
                string sentence = speakerOneSentences.Dequeue();
                StopAllCoroutines();
                nameText.text = speakerOneName; // Display Speaker One's name
                StartCoroutine(TypeSentence(sentence, true));
            }
            else
            {
                EndDialogue();
            }
        }
        else
        {
            if (speakerTwoSentences.Count > 0)
            {
                string playerSentence = speakerTwoSentences.Dequeue();
                StopAllCoroutines();
                nameText.text = playerName; // Display Player's name
                StartCoroutine(TypeSentence(playerSentence, false));
            }
            else
            {
                EndDialogue();
            }
        }
    }

    IEnumerator TypeSentence(string sentence, bool isSpeakerOne)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null; // Type letter by letter
        }

        // Wait for player input to proceed or to open a new panel
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.T));

        // Check if the "T" key was pressed to open the new panel
        if (Input.GetKeyDown(KeyCode.T) && initialPanel != null)
        {
            OpenPanel(initialPanel); // Open the initial panel
            // Wait until the initial panel is closed
            yield return new WaitUntil(() => !initialPanel.activeSelf); 

            // Show the dialogue panel again
            dialoguePanel.SetActive(true);

            // Continue with the next sentence
            DisplayNextSentence(!isSpeakerOne); // Switch turns
        }
        else
        {
            // Continue with the next sentence
            DisplayNextSentence(!isSpeakerOne); // Switch turns
        }
    }

    void EndDialogue()
    {
        dialoguePanel.SetActive(false); // Hide the dialogue panel
    }

    // Method to open a panel
    private void OpenPanel(GameObject panel)
    {
        if (panel != null)
        {
            dialoguePanel.SetActive(false); // Hide the dialogue panel
            panel.SetActive(true); // Activate the panel
            panelStack.Push(panel); // Push the panel to the stack
        }
    }

    // Method to close the current panel (call this from the back button in the panel)
    public void CloseCurrentPanel()
    {
        if (panelStack.Count > 0)
        {
            GameObject currentPanel = panelStack.Pop(); // Get the top panel from the stack
            if (currentPanel != null)
            {
                currentPanel.SetActive(false); // Deactivate the current panel

                // Check if the stack is empty and the initial panel should be shown
                if (panelStack.Count == 0 && initialPanel != null)
                {
                    initialPanel.SetActive(true); // Show the initial panel again
                }

                // Show the dialogue panel when returning to the initial panel
                if (panelStack.Count == 0)
                {
                    dialoguePanel.SetActive(true); // Show the dialogue panel again
                }
            }
        }
    }
}

