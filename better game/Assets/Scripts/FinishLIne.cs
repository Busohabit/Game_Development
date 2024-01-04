using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLIne : MonoBehaviour
{
    public GameObject LevelCompleteScreen;

    private void OnTriggerEnter(Collider other)
    {
        PlayerMovement.Instance.enabled = false;
        LevelCompleteScreen.SetActive(true);
    }
}
