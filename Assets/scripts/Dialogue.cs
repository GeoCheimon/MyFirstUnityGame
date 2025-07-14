using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string speakerOneName = ""; // Name of the first speaker (e.g., Coach)
    public string playerName = "";          // Name of the Player

    [TextArea(3, 10)]
    public string[] speakerOneSentences; // Sentences from Speaker One
    [TextArea(3, 10)]
    public string[] speakerTwoSentences; // Sentences from Player
}
