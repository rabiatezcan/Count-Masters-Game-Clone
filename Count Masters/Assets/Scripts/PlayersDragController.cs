using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayersDragController : MonoBehaviour
{
    private bool isTouching = false;
    private float touchPosX;
    private float movementSpeed = 15f;

    private void Update()
    {
        GetMouseInput();
    }

    private void FixedUpdate()
    {
        if (isTouching)
        {
            touchPosX += Input.GetAxis("Mouse X") * movementSpeed * Time.fixedDeltaTime;
        }

        transform.position = new Vector3(touchPosX, transform.position.y, transform.position.z);
    }

    private void GetMouseInput()
    {
        if (Input.GetMouseButton(0))
        {
            isTouching = true;
        }
        else
        {
            isTouching = false;
        }
    }
}