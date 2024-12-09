using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
  public void loadLevel(string levelName)
  {
        SceneManager.LoadScene(levelName);
  }

  public void quitGame()
    {
        Application.Quit();
#if UNITY_EDITOR

UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
