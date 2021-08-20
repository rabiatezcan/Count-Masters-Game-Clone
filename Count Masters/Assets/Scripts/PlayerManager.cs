using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public delegate void OutOfBoundsHandler();

public delegate void GameOverHandler();

public class PlayerManager : MonoBehaviour
{
    public event OutOfBoundsHandler OutOfBoundsEvent;
    public bool isGameOver = false;
    public bool isLevelFinished;
    [SerializeField] private GameObject playerPrefab;
    private Vector3 deltaVector = new Vector3(0.35f, 0, 0);
    public float planeBound = 2.3f;
    public float zAxisForStair;

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
            }
        }
        if (OutOfBoundsEvent != null)
        {
            OutOfBoundsEvent();
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
                Instantiate(playerPrefab, playerTransform.position + deltaVector, Quaternion.identity);
            }
            else
            {
                Instantiate(playerPrefab, playerTransform.position + (deltaVector * i), Quaternion.identity);
            }
        }
    }

    public void MakeTrianglePlayers()
    {
        int row = RowSize();
        int playerCount = (2 * row) - 1;
        float spaceBetweenPlayers = deltaVector.x ;
        int childIndex = 0;
        float yAxis = -0.26f;
        for (int i = 1; i <= row; i++)
        {
            float xAxis = -planeBound + (spaceBetweenPlayers * (i - 1));
            
            for (int j = 0; j < playerCount; j++)
            {
                xAxis += spaceBetweenPlayers;
                if(childIndex < transform.childCount) 
                    transform.GetChild(childIndex++).position = new Vector3(xAxis, yAxis + (0.6f * i), zAxisForStair);
            }
            playerCount -= 2;
        }
        isLevelFinished = true;
    }

    private int RowSize()
    {
        int row = 0;
        int sum = 0;
        int temp = 1;
        while (sum <= transform.childCount)
        {
            row++;
            temp += 2;
            sum += temp;
        }
        return row;
    }
}