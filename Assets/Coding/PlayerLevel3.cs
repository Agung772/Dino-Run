using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLevel3 : MonoBehaviour
{
    public float kekuatanLoncat;
    Rigidbody2D rb;
    int sensor;
    public int batasLoncat;
    bool tanah = true;
    public int koin;
    public int scoreLevel3, hiScoreLevel3;
    public Text scoreUILevel3, hiScoreUILevel3;
    public Text koinUI;
    string HISCORELevel3 = "HISCORELevel3";
    string COIN = "COIN";
    public GameObject layarKalahUI;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    private void Start()
    {
        hiScoreLevel3 = PlayerPrefs.GetInt(HISCORELevel3);
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
        koin += 3;
        koinUI.text = "Coin : " + koin.ToString();

    }
    void AddScoreLevel1()
    {
        AudioManager.singleton.PlaySound(2);
        scoreLevel3++;
        scoreUILevel3.text = "Score : " + scoreLevel3.ToString();
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

    }
    void PlayerKalah()
    {
        AudioManager.singleton.PlaySound(3);
        if (scoreLevel3 > hiScoreLevel3)
        {
            hiScoreLevel3 = scoreLevel3;
            PlayerPrefs.SetInt(HISCORELevel3, hiScoreLevel3);
        }
        PlayerPrefs.SetInt(COIN, koin);
        hiScoreUILevel3.text = "HiScore : " + hiScoreLevel3.ToString();
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
