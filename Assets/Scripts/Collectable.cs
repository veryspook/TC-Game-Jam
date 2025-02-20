using System.Collections;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        OnCollect();
    }
    public virtual void OnCollect() {
        
    }
    
}
