using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DeathBarrier : MonoBehaviour
{
    private GameObject deathScreen;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            deathScreen = CanvasManager.Instance.deathScreen;

            deathScreen.SetActive(true);

            EventSystem.current.SetSelectedGameObject(CanvasManager.Instance.deathScreenSelect);
        }

    }
}
