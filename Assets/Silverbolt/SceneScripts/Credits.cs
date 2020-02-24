using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public void GoToStartMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
