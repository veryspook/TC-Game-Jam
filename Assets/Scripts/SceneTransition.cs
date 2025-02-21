using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Net.NetworkInformation;

public class SceneTransition : MonoBehaviour
{
    public static string firstWord = "[MISSING]";
    public static string secondWord = "[MISSING]";
    public static string thirdWord = "[MISSING]";
    public Button libraryButton;
    public Button twownButton;
    public TextMeshProUGUI responseText;
    public static bool finishedCity = false;
    public static bool finishedLibrary = false;
    public void ChangeScenes(string sceneName){
        DialogueManager.ended = false;
        SceneManager.LoadScene(sceneName);
    }


    public void ShowLevels() {
        if (finishedLibrary) {
            twownButton.interactable = true;
            libraryButton.interactable = true;
        } else if (finishedCity) {
            twownButton.interactable = false;
            libraryButton.interactable = true;
        } else {
            twownButton.interactable = false;
            libraryButton.interactable = false;
        }
        responseText.text = "Having bred " + firstWord +  " with " + secondWord + ", performing tests delivers " + thirdWord + " diagnosis!";
    }
}
