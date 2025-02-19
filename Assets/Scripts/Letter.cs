using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.LowLevelPhysics;
using TMPro;

public class Letter : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public string letter;
    public LetterSlot slot;
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        GetComponentInChildren<TextMeshProUGUI>().text = letter.ToUpper();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        AudioManager.instance.PlaySound("Letter Grab");
        canvasGroup.blocksRaycasts = false;
        if (slot != null) {
            slot.letter = "";
            slot = null;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        AudioManager.instance.PlaySound("Letter Place");
        canvasGroup.blocksRaycasts = true;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.transform.localScale = Vector3.one * 1.1f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.transform.localScale = Vector3.one;
    }
    
}
