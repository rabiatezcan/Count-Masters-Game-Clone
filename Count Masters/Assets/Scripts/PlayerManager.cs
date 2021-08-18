using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public delegate void OutOfBoundsHandler();

public class PlayerManager : MonoBehaviour
{
    public event OutOfBoundsHandler OutOfBoundsEvent;
    [SerializeField] private GameObject playerPrefab;
    private Vector3 deltaVector = new Vector3(0.35f, 0, 0);

    private void Awake()
    {
        SpawnPlayer(2);
    }
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(touchPos.x, transform.position.y, transform.position.z);
                
                if (OutOfBoundsEvent != null)
                {
                    OutOfBoundsEvent();
                }
            }
        }
    }
    public void SpawnPlayer(int playerCount)
    {
        Transform playerTransform = transform;
        
        if (transform.childCount > 1)
        {
            playerTransform = transform.GetChild(0);
        }
        
        for (int i = 0; i < playerCount; i++)
        {
            float xControl = Mathf.Abs(playerTransform.position.x) + deltaVector.x * i;
            if (xControl >= 2.3f)
            {
                Instantiate(playerPrefab, playerTransform.position + deltaVector,Quaternion.identity);
            }
            else
            {
                Instantiate(playerPrefab, playerTransform.position + (deltaVector * i), Quaternion.identity);
            }
        }
    }
}