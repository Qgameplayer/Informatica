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
        int levelAt = PlayerPrefs.GetInt("levelAt", 2);

        // Loop door alle knoppen (levels)
        for (int i = 1; i < levelButtons.Length; i++)
        {
            if (i + 2 > levelAt)
            {
                levelButtons[i].interactable = false;
            }
        }
    }

    public void OpenLevel(int levelNumber)
    {
        int sceneNumber = levelNumber + 1;
        SceneManager.LoadScene(sceneNumber);
    }


}
