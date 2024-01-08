using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }

    [Header("Scene Information")]
    public string sceneName;

    [Header("Countdown Settings")]
    public float timer;
    public TextMeshProUGUI timerText;

    [Header("Score")]
    public TextMeshProUGUI CoinCounterText;

    [Header("Cameras")]
    public CinemachineVirtualCamera introCamera;
    public CinemachineVirtualCamera playerCamera;

    [Space(10)]
    public int totalCoins;
    public int Score;

    [HideInInspector]
    public bool gameStarted;

    [HideInInspector]
    public bool levelFinished;

    public static bool introComplete;

    private GameObject canvas;

    private void Awake()
    {
        Instance = this;

        canvas = GameObject.Find("Canvas");

        introComplete = PlayerPrefs.GetString("Intro") == "Complete";

        sceneName = SceneManager.GetActiveScene().name;

        if (introComplete)
        {
            introCamera.Priority = 5;
            playerCamera.Priority = 10;
            gameStarted = true;
            canvas.SetActive(true);
        }
        else
        {
            introCamera.Priority = 10;
            playerCamera.Priority = 5;
            canvas.SetActive(false);
        }
    }

    private void Start()
    {
        totalCoins = GameObject.FindGameObjectsWithTag("Coin").Length;

        if (introComplete) return;

        StartCoroutine(StartGame());
    }

    private void Update()
    {
        if (!gameStarted || levelFinished) return;

        timer += Time.deltaTime;
        timer = Mathf.Max(timer, 0f);

        CoinCounterText.text = Score.ToString();

        string formattedTime;

        if (timer >= 60)
        {
            int minutes = Mathf.FloorToInt(timer / 60);
            float seconds = timer % 60;
            formattedTime = string.Format("{0}:{1:00}.{2:000}", minutes, Mathf.FloorToInt(seconds), Mathf.FloorToInt((seconds - Mathf.Floor(seconds)) * 1000));
        }
        else
        {
            formattedTime = timer.ToString("F3");
        }

        timerText.text = formattedTime;
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(2.9f);

        introCamera.Priority = 5;
        playerCamera.Priority = 10;

        PlayerPrefs.SetString("Intro", "Complete");

        yield return new WaitForSeconds(1);

        gameStarted = true;
        canvas.SetActive(true);
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetString("Intro", "False");
    }
}
