using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "DialogueData", menuName = "Dialogue/New Dialogue Data")]
public class DialogueData : ScriptableObject
{
    public List<DialogueEntry> dialogueEntries;

    [System.Serializable]
    public class DialogueEntry
    {
        public enum Speaker {Human, Book}
        public Speaker speaker;
        public Sprite characterSprite;
        public string dialogueText;
    }
}
