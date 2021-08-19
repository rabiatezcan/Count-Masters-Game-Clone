using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float cameraOffset = 8f;
    private GameObject player; 
    void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z - cameraOffset);
    }
}
