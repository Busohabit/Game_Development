using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager Instance { get; set; }

    public TextMeshProUGUI timer;

    public GameObject deathScreen;
    public GameObject levelCompleteScreen;
    public GameObject settingsScreen;

    public GameObject pauseMenu;

    public GameObject pauseMenuButtons;

    public GameObject deathScreenSelect;
    public GameObject levelCompleteScreenSelect;
    public GameObject pauseScreenSelect;

    private bool isPaused = false;


    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (GameManager.Instance.levelFinished)
            timer.text = GameManager.Instance.timerText.text;

        if ((Keyboard.current.escapeKey.wasPressedThisFrame || Gamepad.current != null && Gamepad.current.startButton.wasPressedThisFrame)
        && !GameManager.Instance.levelFinished)
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void LoadScene(string sceneName)
    {
        PlayerPrefs.SetString("Intro", "False");
        SceneManager.LoadScene(sceneName);

        ResumeGame();
    }

    public void LoadNextLevel()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        if (currentSceneName.StartsWith("Level"))
        {
            string levelNumberString = currentSceneName.Substring("Level".Length);
            int currentLevel;

            if (int.TryParse(levelNumberString, out currentLevel))
            {
                int nextLevel = currentLevel + 1;

                string nextLevelSceneName = "Level" + nextLevel;

                if (SceneExists(nextLevelSceneName))
                {
                    PlayerPrefs.SetString("Intro", "False");
                    SceneManager.LoadScene(nextLevelSceneName);
                }
                else
                {
                    Debug.LogWarning("Next level scene does not exist.");
                }
            }
            else
            {
                Debug.LogWarning("Unable to parse current level number.");
            }
        }
        else
        {
            Debug.LogWarning("Current scene is not a level scene.");
        }
    }

    private bool SceneExists(string sceneName)
    {
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
            string sceneNameInBuildSettings = System.IO.Path.GetFileNameWithoutExtension(scenePath);

            if (sceneNameInBuildSettings == sceneName)
            {
                return true;
            }
        }

        return false;
    }

    public void RetryLevel()
    {
        string scene = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene(scene);

        EventSystem.current.SetSelectedGameObject(null);

        ResumeGame();
    }

    void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        EventSystem.current.SetSelectedGameObject(pauseScreenSelect);
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void Quit() {
        Application.Quit();
    }

    public void ToggleSettings() {
        bool isOpen = settingsScreen.activeSelf;

        if (isOpen) {
            pauseMenuButtons.SetActive(true);
            settingsScreen.SetActive(false);
        } else {
            pauseMenuButtons.SetActive(false);
            settingsScreen.SetActive(true);
        }
    }
}
