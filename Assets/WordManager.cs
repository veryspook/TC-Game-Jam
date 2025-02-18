using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class WordManager : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    public string targetWord;
    private string currentWord;
    public GameObject slots;
    public GameObject tiles;
    public GameObject tilePrefab;
    public List<string> lettersToAdd = new List<string>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        CreateTiles();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddLetter(string letter) {
        lettersToAdd.Add(letter);
    }
    public void CreateTiles() {
        while (lettersToAdd.Count > 0) {
            GameObject tile = Instantiate(tilePrefab);
            tile.transform.SetParent(tiles.transform);
            tile.GetComponent<Letter>().letter = lettersToAdd[0];
            tile.GetComponent<Letter>().canvas = canvas;
            lettersToAdd.RemoveAt(0);
        }
    }
    public void CheckWord() {
        currentWord = "";
        foreach (LetterSlot letterSlot in slots.GetComponentsInChildren<LetterSlot>()) {
            currentWord += letterSlot.letter;
        }
        Debug.Log(currentWord);
        if (targetWord.ToUpper() == currentWord) { 
            //trigger win scren
        } else {
            //show incorrect text
        }
    }
}
