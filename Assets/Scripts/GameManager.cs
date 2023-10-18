using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager thisManager = null;  
    [SerializeField] private Text Txt_Score = null;
    [SerializeField] private Text Txt_Message = null;
    private int Score = 0;

    void Start()
    {
        thisManager = this;
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            Time.timeScale = 0;
            PlayerPrefs.SetInt("Score", 0);
        }
    }

    void Update()
    {

        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            if (Time.timeScale == 0 && Input.GetKeyDown(KeyCode.Return))
                StartGame();
        }
        else 
        {
            if (Input.GetKeyDown(KeyCode.R))
                PlayerPrefs.DeleteAll();

            Txt_Score.text = "SCORE: " + PlayerPrefs.GetInt("Score");
            Txt_Message.text = "HIGHSCORE: " + PlayerPrefs.GetInt("HighScore");
        }
    }

    public void UpdateScore(int value)
    {
        Score += value;
        Txt_Score.text = "SCORE : " + Score;
        PlayerPrefs.SetInt("Score", Score);
        print("score" + PlayerPrefs.GetInt("Score"));
    }

    private void StartGame()
    {
        Score = 0;
        Time.timeScale = 1;
        Txt_Message.text = "";
        Txt_Score.text = "SCORE : 0";
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        /*Txt_Message.text = "GAMEOVER! \nPRESS ENTER TO RESTART GAME.";
        Txt_Message.color = Color.red;*/
        if (PlayerPrefs.GetInt("HighScore") < PlayerPrefs.GetInt("Score"))
        {
            print("hs" + PlayerPrefs.GetInt("HighScore"));
            PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("Score"));
        }
        SceneManager.LoadScene("GameOver");
    }

    public void RestartBtn()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
