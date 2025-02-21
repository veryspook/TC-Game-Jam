using System.Collections;
using TMPro;
using UnityEngine;

public class Tile : Collectable
{
    public GameObject partSys;
    public string letter;
    public TextMeshPro letterText;
    public void Start() {
        letterText.text = letter.ToUpper();
    }

    public override void OnCollect()
    {   
        base.OnCollect();
        StartCoroutine("PlayParticles");
        WordManager.instance.AddLetter(letter);
        AudioManager.instance.PlaySound("Letter Collect");
        gameObject.transform.parent.gameObject.SetActive(false);
    }
    public IEnumerator PlayParticles() {
        GameObject particles = Instantiate(partSys);
        particles.transform.position = this.transform.position;
        particles.GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(0.1f);
        Destroy(particles); 
    }
}
