using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StartMenuManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText = null;
    public void LoadNextScene()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Quit()
    {
        Application.Quit();
    }
    private void Start()
    {
        int highScore = PlayerPrefs.GetInt("highScore", 0);
        scoreText.text = "HighScore: " + highScore;
    }
    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}
