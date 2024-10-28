using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highscoreText;
    public static int highscore = 0;
    private void Start()
    {
        if(scoreText != null && highscoreText != null)
        {
            if (GameScore.score > highscore)
            {
                highscore = GameScore.score;
            }

            scoreText.text = "Score:" + GameScore.score;
            highscoreText.text = "Highscore:" + highscore.ToString();
        }
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void GoToGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void GoToLB()
    {
        SceneManager.LoadScene("Leaderboard");
    }

    public void Exit()
    {
        Application.Quit();
    }
}