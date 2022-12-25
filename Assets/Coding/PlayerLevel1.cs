using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLevel1 : MonoBehaviour
{
    public float kekuatanLoncat;
    Rigidbody2D rb;
    int sensor;
    public int batasLoncat;
    bool tanah = true;
    public int koin;
    public int scoreLevel1, hiScoreLevel1;
    public Text scoreUILevel1, hiScoreUILevel1;
    public Text koinUI;
    string HISCORELevel1 = "HISCORELevel1";
    string COIN = "COIN";
    public GameObject layarKalahUI;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Application.targetFrameRate = 60;
    }

    private void Start()
    {
        hiScoreLevel1 = PlayerPrefs.GetInt(HISCORELevel1);
        koin = PlayerPrefs.GetInt(COIN);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!tanah)
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
        koinUI.text = "Coin : " + koin.ToString();
    }
    void AddScoreLevel1()
    {
        AudioManager.singleton.PlaySound(2);
        scoreLevel1++;
        scoreUILevel1.text = "Score : " + scoreLevel1.ToString();
    }
    void loncat()
    {
        if (Input.GetMouseButtonDown(0) && sensor > 0)
        {
            AudioManager.singleton.PlaySound(1);
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
            AddScoreLevel1();

        }
        if (collision.CompareTag("SensorLevel"))
        {
            
            int currentLevel = SceneManager.GetActiveScene().buildIndex;

            if (currentLevel >= PlayerPrefs.GetInt("level1sKunci"))
            {
                PlayerPrefs.SetInt("level1sKunci", currentLevel + 0);

            }
            Debug.Log("LEVEL " + PlayerPrefs.GetInt("level1sKunci") + " TERBUKA");
        }

    }
    void PlayerKalah()
    {
        AudioManager.singleton.PlaySound(3);
        if (scoreLevel1 > hiScoreLevel1)
        {
            hiScoreLevel1 = scoreLevel1;
            PlayerPrefs.SetInt(HISCORELevel1, hiScoreLevel1);
        }
        PlayerPrefs.SetInt(COIN, koin);
        hiScoreUILevel1.text = "HiScore : " + hiScoreLevel1.ToString();
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