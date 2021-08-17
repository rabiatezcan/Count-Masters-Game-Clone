using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    private Vector3 deltaVector = new Vector3(0.35f, 0, 0);
    private GameObject player;
    private void Awake()
    {
        SpawnPlayer(2);
    }

    private void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SpawnPlayer(int playerCount)
    {
        player = FindObjectOfType<PlayersDragController>().gameObject;
        
        for (int i = 0; i < playerCount; i++)
        {
            Instantiate(playerPrefab, player.transform.position + (deltaVector * i) , Quaternion.identity);
        }
    }
}
