using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject levelFinishPanel;
    [SerializeField] private GameObject gameOverPanel;
    private PlayerManager playerManager;
    
    private void Start()
    {
        playerManager = FindObjectOfType<PlayerManager>();
    }

    void Update()
    {
        if (playerManager.isGameOver)
        {
            gameOverPanel.SetActive(true);
        }
        
    }

    public void GoToScene(int value)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + value);
    }

}