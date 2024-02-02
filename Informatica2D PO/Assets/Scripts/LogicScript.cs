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

    private GameObject bobo;
    BoboScript boboScript;

    private GameObject bibiPortal;
    BibiPortalScript bibiPortalScript;

    private GameObject boboPortal;
    BoboPoralScript boboPortalScript;

    private int currentLifes = 3;

    private void Start()
    {
        bibi = GameObject.FindWithTag("Bibi");
        bibiScript = bibi.GetComponent<BibiScript>();

        bobo = GameObject.FindWithTag("Bobo");
        boboScript = bobo.GetComponent<BoboScript>();

        bibiPortal = GameObject.FindWithTag("BibiPortal");
        bibiPortalScript = bibiPortal.GetComponent<BibiPortalScript>();

        boboPortal = GameObject.FindWithTag("BoboPortal");
        boboPortalScript = boboPortal.GetComponent<BoboPoralScript>();
    }
    private void Update()
    {
        //Debug.Log(bibiScript.bibiCollisionScript.isInBibiPortal + " " + bibiPortalScript.isPortalActivated + " " + boboScript.boboCollisionScript.isInBoboPortal + " " + boboPortalScript.isPortalActivated);

        if (bibiScript.bibiCollisionScript.isInBibiPortal && bibiPortalScript.isPortalActivated && boboScript.boboCollisionScript.isInBoboPortal && boboPortalScript.isPortalActivated)
        {
            LoadNextScene();
        }
    }
    public void HandlePlayerDeath(GameObject deadPlayer)
    {
        currentLifes--;
        if (currentLifes == 0)
        {
            GameOver();
        }
        else
        {
            RespawnPlayer(deadPlayer);
        }
    }

    private void RespawnPlayer(GameObject player)
    {
        if (player == bibi)
        {
            Vector2 spawnPos = bibiScript.spawnPos;
            bibi.transform.position = spawnPos;
        }

        else if (player == bobo)
        {
            Vector2 spawnPos = boboScript.spawnPos;
            bobo.transform.position = spawnPos;
        }
    }

    private void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
