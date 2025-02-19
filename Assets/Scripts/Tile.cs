using TMPro;
using UnityEngine;

public class Tile : Collectable
{
    public string letter;
    public TextMeshPro letterText;
    public void Start() {
        letterText.text = letter;
    }

    public override void OnCollect()
    {
        WordManager.instance.AddLetter(letter);
        AudioManager.instance.PlaySound("Letter Collect");
        base.OnCollect();

    }
}
