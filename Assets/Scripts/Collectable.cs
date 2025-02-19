using UnityEngine;

public class Collectable : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("collecting");
        OnCollect();
    }
    public virtual void OnCollect() {
        Destroy(gameObject.transform.parent.gameObject);
    }
}
