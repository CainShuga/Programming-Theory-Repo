using UnityEngine;
using UnityEngine.EventSystems;

public class ClickableObject : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        // Detect button type (Left, Right, Middle) and click count
        Debug.Log($"Clicked with: {eventData.button}, Count: {eventData.clickCount}");
    }
}