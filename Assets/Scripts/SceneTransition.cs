using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    void Start() {
        gameObject.SetActive(true);
    }
    public Animator anim;
    public void ChangeScenes(string sceneName){
        SceneManager.LoadScene(sceneName);
    }    
    public void Exit() {
        gameObject.SetActive(true);
        anim.SetTrigger("Exit");
    }
    public void Disable() {
        gameObject.SetActive(false);
    }
}
