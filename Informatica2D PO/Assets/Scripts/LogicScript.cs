using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{

    private GameObject bibi;
    BibiScript bibiScript;


    private int currentLifes = 3;

    private void Start()
    {
        bibi = GameObject.FindWithTag("Bibi");
        bibiScript = bibi.GetComponent<BibiScript>();
    }

    public void TakeLifeOff()
    {
        currentLifes--;
        if (currentLifes == 0)
        {
            
        }

    }

    public void HandlePlayerDeath()
    {
        currentLifes--;
        if (currentLifes == 0)
        {
            GameOver();
        }
        if (currentLifes != 0)
        {
            RestartLevel();
        }
    }

    private void RestartLevel()
    {
        Vector2 spawnPos = bibiScript.spawnPos;
        bibi.transform.position = spawnPos;
    }

    private void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
