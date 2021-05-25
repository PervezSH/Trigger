using UnityEngine;
using UnityEngine.EventSystems;

public class move_by_touch : MonoBehaviour, IDragHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }
}
