using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int enemyCount;
    private float axisX;
    private float axisY = 0.5f;
    private float axisZ;

    void Start()
    {
        axisX = transform.position.x + gameObject.GetComponent<SphereCollider>().radius;
        axisZ = transform.position.z + gameObject.GetComponent<SphereCollider>().radius;
        SpawnEnemy(enemyCount);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.parent.childCount > transform.childCount)
        {
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Dead");
        }
    }
    

    private void SpawnEnemy(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(transform.position.x,axisX), axisY, Random.Range(transform.position.z, axisZ));
            GameObject enemy = Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
            enemy.transform.parent = transform;
            Vector3.MoveTowards(enemy.transform.position, gameObject.transform.position, 100f);
        }
    }
}