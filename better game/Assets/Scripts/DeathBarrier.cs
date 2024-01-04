using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathBarrier : MonoBehaviour
{
    public GameObject DeathScreen;

    private void OnTriggerEnter(Collider other)
    {
        DeathScreen.SetActive(true);
    }

    public void Restart()
    {
        // Get the current scene name
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Reload the current scene
        SceneManager.LoadScene(currentSceneName);
    }
}
