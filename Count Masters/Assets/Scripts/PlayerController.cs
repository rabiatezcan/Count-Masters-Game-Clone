using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerManager playerManager;
    private Rigidbody rigidbody;
    private float speed = 6f;

    private void Awake()
    {
        playerManager = FindObjectOfType<PlayerManager>();
    }

    void Start()
    {
        transform.parent = playerManager.gameObject.transform;
        rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        playerManager.OutOfBoundsEvent += OutOfBounds;
    }

    private void OnDisable()
    {
        playerManager.OutOfBoundsEvent -= OutOfBounds;
    }

    void Update()
    {
        MoveForward();
    }

    public void MoveForward()
    {
        rigidbody.velocity = transform.forward * speed;
    }

    public void OutOfBounds()
    {
        float direction = 1; 
        if (Mathf.Abs(transform.position.x) > playerManager.planeBound)
        {
            if (transform.position.x < 0)
            {
                direction = -1; 
            }
            transform.position = new Vector3(playerManager.planeBound * direction, transform.position.y, transform.position.z);
        }
        if (transform.position.y < -0.2f)
        {
            Destroy(gameObject);
        }
    }
}