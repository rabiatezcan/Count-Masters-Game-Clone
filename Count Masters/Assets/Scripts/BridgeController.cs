using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeController : MonoBehaviour
{
    private bool isTrigged = false;

    [SerializeField] Transform rightBridge;
    [SerializeField] private Transform leftBridge;
    private void OnCollisionEnter(Collision other)
    {
        if (!isTrigged)
        {
            rightBridge.Rotate(-90f,0f,0f);
            leftBridge.Rotate(90f,0f,0f);
            isTrigged = true;
        }

        gameObject.GetComponent<SphereCollider>().isTrigger = true;
    }
}
