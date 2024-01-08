using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AsyncLevelLoader : MonoBehaviour
{
  public static AsyncLevelLoader Instance { get; set; }

  [SerializeField] private GameObject loadingScreen;
  [SerializeField] private GameObject mainMenu;

  [SerializeField] private Slider loadingSlider;
  [SerializeField] private Image backgroundImg;

  private void Awake()
  {
    Instance = this;
  }

  public void LoadLevel(string level)
  {
    mainMenu.SetActive(false);
    loadingScreen.SetActive(true);

    Sprite background = Resources.Load<Sprite>("Level_" + level);

    backgroundImg.sprite = background;
    StartCoroutine(LoadLevelAsync(level));
  }

  IEnumerator LoadLevelAsync(string level)
  {
    yield return new WaitForSeconds(1);

    AsyncOperation load = SceneManager.LoadSceneAsync(level);

    while (!load.isDone)
    {
      float progress = Mathf.Clamp01(load.progress / 0.9f);
      loadingSlider.value = progress;
      yield return null;
    }
  }

}

