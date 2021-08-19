using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairController : MonoBehaviour
{
    private PlayerManager playerManager;
    void Start()
    {
        playerManager = FindObjectOfType<PlayerManager>();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {        
        playerManager.zAxisForStair = GetComponent<BoxCollider>().transform.position.z;
        playerManager.MakeTrianglePlayers();
        gameObject.GetComponent<BoxCollider>().isTrigger = true;

    }
}
