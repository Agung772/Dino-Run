using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int level1sKunci;
    public Button[] tombol;
    // Start is called before the first frame update

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
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
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            for (int i = 0; i < tombol.Length; i++)
            {
                tombol[i].interactable = true;
            }
        }
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
