using UnityEngine;
using UnityEngine.EventSystems;

public class LetterSlot : MonoBehaviour, IDropHandler
{
    public string letter;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null) {
            letter = eventData.pointerDrag.GetComponent<Letter>().letter;
            eventData.pointerDrag.GetComponent<Letter>().slot = this;
            AudioManager.instance.PlaySound("Letter Place");
            eventData.pointerDrag.transform.position = this.gameObject.transform.position;

        }
    }
}
