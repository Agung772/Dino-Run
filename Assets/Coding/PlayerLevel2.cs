using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLevel2 : MonoBehaviour
{
    public float kekuatanLoncat;
    Rigidbody2D rb;
    int sensor;
    public int batasLoncat;
    bool tanah = true;
    public int koin;
    public int scoreLevel2, hiScoreLevel2;
    public Text scoreUILevel2, hiScoreUILevel2;
    public Text koinUI;
    string HISCORELevel2 = "HISCORELevel2";
    string COIN = "COIN";
    public GameObject layarKalahUI;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    private void Start()
    {
        hiScoreLevel2 = PlayerPrefs.GetInt(HISCORELevel2);
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
        koin += 2;
        koinUI.text = "Coin : " + koin.ToString();

    }
    void AddScoreLevel1()
    {
        AudioManager.singleton.PlaySound(2);
        scoreLevel2++;
        scoreUILevel2.text = "Score : " + scoreLevel2.ToString();
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
        if (scoreLevel2 > hiScoreLevel2)
        {
            hiScoreLevel2 = scoreLevel2;
            PlayerPrefs.SetInt(HISCORELevel2, hiScoreLevel2);
        }
        PlayerPrefs.SetInt(COIN, koin);
        hiScoreUILevel2.text = "HiScore : " + hiScoreLevel2.ToString();
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
