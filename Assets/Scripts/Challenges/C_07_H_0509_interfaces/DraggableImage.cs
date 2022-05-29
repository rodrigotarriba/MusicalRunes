using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class DraggableImage : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Image image;
    private Vector3 initialPos;
    private Vector3 finalPos;


    
    //When drag ends a cube is instanced on initial location
    //Cube is thrown in the direction of the swipe, at the speed of the throw
    //When new swipe occurs, last cube is killed





    //private Vector2 clickOffset;
    private Vector3 lastPos;

    private void Awake()
    {
        image = GetComponent<Image>();
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        //image.color = Color.black;
        initialPos = eventData.position;
        Debug.Log(initialPos);

        //var eventPosition = new Vector3(eventData.position.x, eventData.position.y, 0);
        //var offsetV3 = transform.position - eventPosition;
        //clickOffset = new Vector2(offsetV3.x, offsetV3.y);
        //Debug.Log(clickOffset);
    }

    public void OnDrag(PointerEventData eventData)
    {

        //transform.position = eventData.position + clickOffset + new Vector2(30,30);
        //Debug.Log(clickOffset);
        //transform.position = eventData.position + clickOffset;



    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //image.color = Color.white;
    }
}
