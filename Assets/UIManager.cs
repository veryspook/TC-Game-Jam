using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject wordMenu;
    [SerializeField]
    public WordManager wordManager;
    // Update is called once per frame
    void Start() {
        WordManager.instance = wordManager;
    }
    void Update()
    {
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
            if (pauseMenu.activeSelf) {
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
            } else {
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
            }
        } 
    }


}
