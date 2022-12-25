using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public void Pass()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;

        if(currentLevel >= PlayerPrefs.GetInt("level1sKunci"))
        {
            PlayerPrefs.SetInt("level1sKunci", currentLevel + 1);

        }
        Debug.Log("LEVEL " + PlayerPrefs.GetInt("level1sKunci") + " UNLOCKED");
    }
}
