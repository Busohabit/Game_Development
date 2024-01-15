using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager Instance { get; set; }

    [Header("Menus")]
    public GameObject mainMenu;
    public GameObject levelSelect;
    public GameObject settingsMenu;

    [Header("Cameras")]
    public CinemachineFreeLook mainMenuCamera;
    public CinemachineFreeLook levelSelectCamera;

    [Header("First Selected")]
    public GameObject mainMenuFirst;
    public GameObject levelSelectFirst;

    [Header("Menu List")]
    public List<GameObject> menus = new List<GameObject>();
    public GameObject currentMenu;

    private void Awake()
    {
        Instance = this;
        currentMenu = mainMenu;
        SetActiveMenu(currentMenu);
    }

    public bool OnMenuScreen()
    {
        return mainMenu.activeSelf;
    }

    public void MenuSelect(GameObject menu)
    {
        SetActiveMenu(menu);
    }

    public void Back()
    {
        SetActiveMenu(mainMenu);
    }

    private void SetActiveMenu(GameObject menu)
    {
        foreach (var m in menus)
        {
            m.SetActive(m == menu);
        }

        currentMenu = menu;

        mainMenuCamera.Priority = (mainMenu == currentMenu) ? 11 : 0;
        levelSelectCamera.Priority = (levelSelect == currentMenu) ? 11 : 0;

        GameObject firstSelected = (currentMenu == mainMenu) ? mainMenuFirst : levelSelectFirst;
        EventSystem.current.SetSelectedGameObject(firstSelected);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
