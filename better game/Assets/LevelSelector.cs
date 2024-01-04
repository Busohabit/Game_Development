using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    // Buttons for each level
    public Button[] levelButtons;

    private void Start()
    {
        // Attach a click event to each level button
        for (int i = 0; i < levelButtons.Length; i++)
        {
            int levelIndex = i + 1;  // Levels are usually 1-indexed
            levelButtons[i].onClick.AddListener(() => LoadLevel(levelIndex));
        }
    }

    private void LoadLevel(int levelIndex)
    {
        // Scene names are like "Level1", "Level2", etc.
        string sceneName = "Level" + levelIndex;

        // Load the selected level
        SceneManager.LoadScene(sceneName);
    }
}
