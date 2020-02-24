using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WrongHoles : MonoBehaviour
{
    [SerializeField] private GameObject LoseText = default;
    [SerializeField] private CurrentScore score = default;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) { //android back button
            if (score.score > PlayerPrefs.GetInt("highScore", 0))
            {
                PlayerPrefs.SetInt("highScore", (int)score.score);
            }
            score.score = 0;
            LoadFirstScene();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "HoleDetector")
        {
            Instantiate(LoseText);
            if (score.score > PlayerPrefs.GetInt("highScore", 0)) {
                PlayerPrefs.SetInt("highScore", (int)score.score);
            }
            score.score = 0;
            Time.timeScale = 0.01f;
            Invoke("LoadFirstScene", .025f);
        }
    }
    void LoadFirstScene()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
