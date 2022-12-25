using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Back : MonoBehaviour
{
    public Button back;

    public void BackMainMenu(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }
}
