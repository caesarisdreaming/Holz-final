using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RightHoles : MonoBehaviour
{
    [SerializeField] private GameObject Wintext = default;
    float startTime;
    private bool addedScore = false;
    [SerializeField] private CurrentScore score = default;
    private void Start()
    {
        startTime = Time.realtimeSinceStartup;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        { //android back button
            if (score.score > PlayerPrefs.GetInt("highScore", 0))
            {
                PlayerPrefs.SetInt("highScore", (int)score.score);
            }
            score.score = 0;
            SceneController.LoadFirstScene();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "HoleDetector")
        {
            Instantiate(Wintext);
            //Time.timeScale = 0.01f;
            //Invoke("LoadNextScene", .025f);
            float timeToWin = Time.realtimeSinceStartup - startTime;
            if (!addedScore)
            {
                score.score += (1 / timeToWin) * 60;
                addedScore = true;
            }
            LoadNextScene();

        }
    }
    private void LoadNextScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        if ((scene.buildIndex < SceneManager.sceneCountInBuildSettings-1)) {//if this isn't the last Scene
            SceneController.LoadNextScene();
        }
        else//if this is the last scene
        {
            if (score.score > PlayerPrefs.GetInt("highScore", 0))
            {
                PlayerPrefs.SetInt("highScore", (int)score.score);
            }
            Time.timeScale = 0.01f;
            Instantiate(Wintext);
            Invoke("LoadSceneDelayer", .03f);
        }
    }
    private void LoadSceneDelayer()
    {
        SceneController.LoadFirstScene();
    }
}
