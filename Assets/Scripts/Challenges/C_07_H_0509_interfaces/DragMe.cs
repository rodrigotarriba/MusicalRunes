using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragMe : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // Implementations need to be public in order for the interface to be able to act upon them
    public void OnBeginDrag(PointerEventData data)
    {
        Debug.Log("OnBeginDrag");
    }

    public void OnDrag(PointerEventData data2)
    {
        Debug.Log("OnMouseDrag");
    }

    public void OnEndDrag(PointerEventData data3)
    {
        Debug.Log("OnEndDrag");
    }
}
