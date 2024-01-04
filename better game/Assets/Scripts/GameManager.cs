using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Create instance of GameManager, there should only be one GM in scene at any given time
    public static GameManager Instance { get; set; }

    [Header("Countdown Settings")]
    public float timer;
    public TextMeshProUGUI timerText;

    [Header("Score")]
    public TextMeshProUGUI CoinCounterText;

    public int Score;

    private void Awake()
    {
        //Asigning the Instance to this GameObject
        Instance = this;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        timer = Mathf.Max(timer, 0f);

        CoinCounterText.text = Score.ToString();

        string formattedTime;

        // This shit is just basic maths I'm sure you can figure it out
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

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
