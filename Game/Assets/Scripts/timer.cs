using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    float time;
    // Start is called before the first frame update
    void Start()
    {
        time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;
        int seconds = (int) (time % 60);
        int minutes = (int) (time / 60);
        TextMeshProUGUI timerText = GameObject.Find("timerUI").GetComponent<TextMeshProUGUI>();
        timerText.text = $"{minutes:00}:{seconds:00}";
        TextMeshProUGUI userMessageText = GameObject.Find("userMessageUI").GetComponent<TextMeshProUGUI>();
        if (time > 80){
            userMessageText.text = "Almost out of time";
        }
        if (time > 90){
            SceneManager.LoadScene("SampleScene");

        }

    }
}
