using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    private Vector3 deltaVector = new Vector3(0.35f, 0, 0);
    void Start()
    {
        Instantiate(playerPrefab, gameObject.transform.position, Quaternion.identity);
        Instantiate(playerPrefab, gameObject.transform.position + deltaVector , Quaternion.identity);
    }

    void Update()
    {
        
    }
}
