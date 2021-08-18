using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private PlayerManager playerManager;
    [SerializeField] private int rightTMPValue;
    [SerializeField] private int leftTMPValue;
    [SerializeField] private GameObject rightTMP;
    [SerializeField] private GameObject leftTMP;
    private bool isTrigged = false;

    void Start()
    {
        playerManager = FindObjectOfType<PlayerManager>();

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
                playerManager.SpawnPlayer(rightTMPValue);
                rightTMP.SetActive(false);
            }
            else
            {
                playerManager.SpawnPlayer(leftTMPValue);
                leftTMP.SetActive(false);
            }
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
        }
    }
}