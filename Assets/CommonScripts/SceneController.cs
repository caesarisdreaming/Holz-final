using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneController
{
    public static void LoadFirstScene()
    {
        SceneManager.LoadScene("StartMenu");
    }
    public static void LoadNextScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex + 1);
    }
}
