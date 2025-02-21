using UnityEngine;
using UnityEngine.Tilemaps;

public class Bookshelves : MonoBehaviour
{
    public Player book;
    public TilemapCollider2D col;
    void Update()
    {
        if (book.gameObject.activeSelf) {
            col.enabled = false;
        } else {
            col.enabled = true;
        }
    }
}
