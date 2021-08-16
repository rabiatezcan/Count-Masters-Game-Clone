using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidbody;
    private float speed = 5f;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MoveForward();
    }

    public void MoveForward()
    {
        rigidbody.AddForce(transform.forward * speed, ForceMode.Force);
    }
}
