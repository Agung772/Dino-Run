using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float kekuatanLoncat;
    Rigidbody2D rb;
    int sensor;
    public int batasLoncat;
    bool tanah = true;
    public int koin;
    public int score, hiScore;
    public Text scoreUI, hiScoreUI;
    public Text koinUI;
    string HISCORE = "HISCORE";
    string COIN = "COIN";
    public GameObject layarKalahUI;
    
  
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    
    }

    private void Start()
    {
        hiScore = PlayerPrefs.GetInt(HISCORE);
        koin = PlayerPrefs.GetInt(COIN);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!tanah)
        {
            tanah = true;
        }
        if (collision.collider.CompareTag("mati"))
        {
            PlayerKalah();
        }
    }
    private void Update()
    {
        loncat();

        if (tanah)
        {
            sensor = batasLoncat;
        }
    }
    void AddKoin()
    {
        koin++;
        koinUI.text = "Coin : " +koin.ToString();
        
    }
    void AddScore()
    {
        score++;
        scoreUI.text = "Score : " + score.ToString();
    }
    void loncat()
    {

        if (Input.GetMouseButtonDown(0)&& sensor > 0)
        {
            rb.velocity = Vector2.up * kekuatanLoncat;
            tanah = false;
            sensor--;
        }
        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Koin"))
        {
            AddKoin();

        }
        if (collision.CompareTag("score"))
        {
            AddScore();

        }
        
    }
    void PlayerKalah()
    {
        if (score > hiScore)
        {
            hiScore = score;
            PlayerPrefs.SetInt(HISCORE, hiScore);
        }
        PlayerPrefs.SetInt(COIN, koin);
        hiScoreUI.text = "HiScore : " + hiScore.ToString();
        Time.timeScale = 0;
        layarKalahUI.SetActive(true);
    }
    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
        Time.timeScale = 1;
    }
    public void UlangGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }



}