using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameObject playersObject; 
    private Rigidbody rigidbody;
    private float speed = 5f;
    
    void Start()
    {
        playersObject = GameObject.FindGameObjectWithTag("Player");
        transform.parent = playersObject.transform;
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
