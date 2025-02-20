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



    private void Start()
    {   
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

    if (currentEntry.speaker == DialogueData.DialogueEntry.Speaker.Human) {
        left.sprite = currentEntry.characterSprite;
        left.color = Color.white;
        right.color = new Color(0.8f,0.8f,0.8f);
    }
    if (currentEntry.speaker == DialogueData.DialogueEntry.Speaker.Book) {
        right.sprite = currentEntry.characterSprite;
        left.color = new Color(0.8f,0.8f,0.8f);
        right.color = Color.white;
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
