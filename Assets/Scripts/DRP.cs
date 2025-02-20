using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class DRP : Collectable
{
    public GameObject partSys;
    public override void OnCollect()
    {
        base.OnCollect();
        StartCoroutine("PlayParticles");
        UIManager.instance.AddDRP(gameObject);
        gameObject.SetActive(false);
        AudioManager.instance.PlaySound("Letter Collect");

    }
    public IEnumerator Respawn() {
        yield return new WaitForSeconds(2);
        gameObject.SetActive(true);
    }
    public IEnumerator PlayParticles() {
        GameObject particles = Instantiate(partSys);
        particles.transform.position = this.transform.position;
        particles.GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(0.1f);
        Destroy(particles); 
    }
}
