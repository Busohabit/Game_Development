using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FinishLIne : MonoBehaviour
{
    private GameObject levelCompleteScreen;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            levelCompleteScreen = CanvasManager.Instance.levelCompleteScreen;

            PlayerMovement.Instance.enabled = false;
            levelCompleteScreen.SetActive(true);
            GameManager.Instance.levelFinished = true;
            EventSystem.current.SetSelectedGameObject(CanvasManager.Instance.levelCompleteScreenSelect);
        }
    }
}
