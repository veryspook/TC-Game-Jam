using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour
{
    public DialogueData dialogueData;
    [SerializeField]
    public GameObject nextIndicator;
    public TextMeshProUGUI dialogueText;
    private bool isTyping = false;
    private string completeText;
    public static bool ended = false;
    private int currentDialogueIndex = 0;

    [SerializeField] private Image left; 
    [SerializeField] private Image right;
    [SerializeField] private Image box;
    [SerializeField] private Sprite humanBox;
    [SerializeField] private Sprite bookBox;



    private void Awake()
    {   
        Time.timeScale = 1;
        ended = false;
        ShowDialogue();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetMouseButtonDown(0))
        {
                if (isTyping)
                {
                    StopAllCoroutines();
                    dialogueText.text = completeText;
                    isTyping = false;
                    nextIndicator.SetActive(true);
                }
                else
                {
                    currentDialogueIndex++;
                    ShowDialogue();
                }            

        }
    }

private void ShowDialogue() {
    //debugging logs
    Debug.Log("ShowDialogue called - currentDialogueIndex: " + currentDialogueIndex);
    nextIndicator.SetActive(false);

    if (dialogueData == null)
    {
        Debug.LogError("dialogueData is null");
        return;
    }

    //end of the dialogue
    if (currentDialogueIndex >= dialogueData.dialogueEntries.Count && ended == false)
    {
        ended = true;
        gameObject.SetActive(false);
        return;            
    }

    DialogueData.DialogueEntry currentEntry = dialogueData.dialogueEntries[currentDialogueIndex];
    if (currentEntry == null)
    {
        Debug.LogError("currentEntry is null");
        return;
    }

    if (currentEntry.speaker == DialogueData.DialogueEntry.Speaker.Book) {
        box.sprite = bookBox;
        left.sprite = currentEntry.characterSprite;
        left.color = Color.white;
        right.color = new Color(0.8f,0.8f,0.8f);
        dialogueText.color = new Color(0.1134745f, 0.1778028f, 0.3207547f);
    }
    if (currentEntry.speaker == DialogueData.DialogueEntry.Speaker.Human) {
        box.sprite = humanBox;
        right.sprite = currentEntry.characterSprite;
        left.color = new Color(0.8f,0.8f,0.8f);
        right.color = Color.white;
        dialogueText.color = new Color(0.8679245f, 0.8605164f, 0.7901388f);
    }

    completeText = currentEntry.dialogueText;
    StartCoroutine(TypeText(completeText));
}



    private System.Collections.IEnumerator TypeText(string textToType)
    {
        isTyping = true;
        dialogueText.text = "";
        foreach (char letter in textToType.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.03f); //this can be adjusted for typing speed
        }
        
        isTyping = false;
        nextIndicator.SetActive(true);
    }
}
