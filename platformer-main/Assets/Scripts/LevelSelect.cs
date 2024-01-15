using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public string levelName;

    private void Update()
    {
        if (IsMouseOverObject() && Mouse.current.leftButton.wasPressedThisFrame)
        {
            LoadLevel();
        }
    }

    private bool IsMouseOverObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            return hit.collider.gameObject == gameObject;
        }

        return false;
    }

    private void LoadLevel()
    {
        AsyncLevelLoader.Instance.LoadLevel(levelName);
    }
}
