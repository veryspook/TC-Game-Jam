using System.Collections.Generic;
using System.Globalization;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject wordMenu;
    public GameObject winMenu;
    public TextMeshProUGUI winWord;
    public TextMeshProUGUI winWord2;
    public bool win = false;
    public static UIManager instance;
    [SerializeField]
    public WordManager wordManager;
    public int extraJumps = 0;
    private Stack<GameObject> drpsToRespawn = new Stack<GameObject>();
    [SerializeField] private GameObject drpUI;
    // Update is called once per frame
    void Start() {
        instance = this;
        WordManager.instance = wordManager;
        if (drpUI != null) {
            drpUI.SetActive(true);
            drpUI.GetComponentInChildren<TextMeshProUGUI>().text = 0.ToString();
        }
    }
    void Update()
    {
        if (DialogueManager.ended && !win) {
            if (Input.GetKeyDown(KeyCode.E)) {
                if (wordMenu.activeSelf) {
                    wordMenu.SetActive(false);
                    Time.timeScale = 1;
                } else {
                    wordMenu.SetActive(true);
                    Time.timeScale = 0;
                }
            }
            if (Input.GetKeyDown(KeyCode.P)) {
                TogglePause();
            } 
        }
    }
    public void CompleteLevel(string word) {
        winMenu.SetActive(true);
        wordMenu.SetActive(false);
        win = true;
        winWord.text = word;
        winWord2.text = word;
        

        if (SceneManager.GetActiveScene().name == "City") {
            SceneTransition.finishedCity = true;
            SceneTransition.firstWord = word;
        } else if (SceneManager.GetActiveScene().name == "Library") {
            SceneTransition.finishedLibrary = true;
            SceneTransition.secondWord = word;
        } else {
            SceneTransition.thirdWord = word;
        }
    }
    public void AddDRP(GameObject drp) {
        extraJumps++;
        drpsToRespawn.Push(drp);
        drpUI.GetComponentInChildren<TextMeshProUGUI>().text = extraJumps.ToString();
    }
    public void UseDRP() {
        extraJumps--;
        drpUI.GetComponentInChildren<TextMeshProUGUI>().text = extraJumps.ToString();
        StartCoroutine(drpsToRespawn.Pop().GetComponent<DRP>().Respawn());
    }
    public void TogglePause() {
        if (pauseMenu.activeSelf) {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        } else {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

}
