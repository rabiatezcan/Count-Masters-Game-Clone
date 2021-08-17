using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private GameController gameController;
    [SerializeField] private int rightTMPValue;
    [SerializeField] private int leftTMPValue;
    [SerializeField] private GameObject rightTMP;
    [SerializeField] private GameObject leftTMP;
    private bool isTrigged = false;

    void Start()
    {
        gameController = FindObjectOfType<GameController>();

        rightTMP.GetComponent<TextMeshPro>().text = "+" + rightTMPValue.ToString();
        leftTMP.GetComponent<TextMeshPro>().text = "+" + leftTMPValue.ToString();
    }

    void Update()
    {
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!isTrigged)
        {
            isTrigged = true;
            if (other.transform.position.x > 0)
            {
                gameController.SpawnPlayer(rightTMPValue);
                rightTMP.SetActive(false);
            }
            else
            {
                gameController.SpawnPlayer(leftTMPValue);
                leftTMP.SetActive(false);
            }

            gameObject.GetComponent<BoxCollider>().isTrigger = true;
        }
    }
}