using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public delegate bool OutOfBoundsHandler();

public class PlayersDragController : MonoBehaviour
{
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            if( touch.phase == TouchPhase.Moved)
            { 
                transform.position = new Vector3(touchPos.x,transform.position.y, transform.position.z) ;
            }
        }
 
    }
}