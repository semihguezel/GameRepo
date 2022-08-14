using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Level : MonoBehaviour
{
    [SerializeField] private float delayInSeconds = 2f;
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    public void ReturnStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
        FindObjectOfType<GameSession>().ResetScore();
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void GameOverScreen()
    {
        StartCoroutine(WaitAndLoad());
    }

    IEnumerator  WaitAndLoad()
    {
        yield return new WaitForSecondsRealtime(delayInSeconds);
        SceneManager.LoadScene("GameOver");
    }

    public void GG()
    {
        SceneManager.LoadScene("GameOver");
    }
}

