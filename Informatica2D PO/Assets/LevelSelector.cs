using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] Button[] levelButtons;

    private void Start()
    {

    }

    public void OpenLevel(int levelNumber)
    {
        int sceneNumber = levelNumber + 1;
        SceneManager.LoadScene(sceneNumber);
    }


}
