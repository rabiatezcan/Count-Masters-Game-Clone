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
        playerManager.MakeTrianglePlayers();
    }
}
