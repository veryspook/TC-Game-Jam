using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private string timer;
    private float time;
    
    void Update()
    {
        if (DialogueManager.ended) {
            time += Time.deltaTime;
        }
        int minutes = (int)(time / 60); 
        int seconds = (int)(time % 60); 
        float milliseconds = (time * 1000) % 1000; // Extract milliseconds
        timer = string.Format("{0:00}:{1:00}.{2:000}", minutes, seconds, (int)milliseconds);
        timerText.text = timer;
    }
}
