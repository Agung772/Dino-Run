using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    int level1sKunci;
    public Button[] tombol;
    // Start is called before the first frame update
    void Start()
    {

       
        level1sKunci = PlayerPrefs.GetInt("level1sKunci", 1);
        for (int i = 0; i < tombol.Length; i++)
        {
            tombol[i].interactable = false;
        }
        for (int i = 0; i < level1sKunci; i++)
        {
            tombol[i].interactable = true;
        }
    }
    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
    public void RESET()
    {
        PlayerPrefs.DeleteAll();
    }
}
