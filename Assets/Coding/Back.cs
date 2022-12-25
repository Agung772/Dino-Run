using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Back : MonoBehaviour
{
    public Button back;
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
    public void BackMainMenu(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }
}
