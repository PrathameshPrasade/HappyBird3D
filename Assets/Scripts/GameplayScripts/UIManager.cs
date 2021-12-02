using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public enum Difficulty {Easy = 0, Medium = 1, Hard = 2};
public class UIManager : MonoBehaviour
{
    public static UIManager Instance = null;
    public TextMeshProUGUI m_ScoreTxt, m_EndScoreTxt;
    public Difficulty m_CurrentDifficulty = Difficulty.Medium;
    int m_score = 0;
    public List<Image> m_lstDifficultyHighlightImg = new List<Image>();
    string m_isPlayingFirstTimeKey = "IS_PLAYING_FIRST_TIME";
    int m_isPlayingFirstTimeValue = 0;
    void Awake()
    {
        Instance = this;
    }
    public void AddScore()
    {
        m_score++;
        UpdateScoreText();
    }
    public void ResetScore()
    {
        m_score = 0;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        m_ScoreTxt.text = m_score.ToString();
    }

    public void OnDifficultyChanged(int a_value)
    {
        m_CurrentDifficulty = (Difficulty)a_value;
        for(int i=0; i<m_lstDifficultyHighlightImg.Count; i++)
        {
            if(i == a_value)
                m_lstDifficultyHighlightImg[i].color = Color.green;
            else
                m_lstDifficultyHighlightImg[i].color = Color.white;
        }
        m_lstDifficultyHighlightImg[a_value].color = Color.green;
        switch(m_CurrentDifficulty)
        {
            case Difficulty.Easy:
                ObstracleController.Instance.ObstracleYoffset = 3.0f;
            break;
            case Difficulty.Medium:
                ObstracleController.Instance.ObstracleYoffset = 4.0f;
            break;
            case Difficulty.Hard:
                ObstracleController.Instance.ObstracleYoffset = 5.0f;
            break;
        }
    }
    public void OnTappedAnywhere()
    {
        m_isPlayingFirstTimeValue = PlayerPrefs.GetInt(m_isPlayingFirstTimeKey,0);
        if(m_isPlayingFirstTimeValue == 0)
        {
            GameFSM.Instance.TransitionTo(StateInstructions.Instance);
            PlayerPrefs.SetInt(m_isPlayingFirstTimeKey,1);
        }
        else // Not playing for the first time
        {
            StartGameNow();
        }
    }
    public void StartGameNow()
    {
        GameFSM.Instance.TransitionTo(StateGamePlay.Instance);
    }

    public void OnRestart()
    {
        //Prathamesh: Instead of reloading scene manually resetting everything is better, But due to lack of time I am taking the shortcut.
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex); 
        Time.timeScale = 1.0f;
    }
    public void UpdateScoreOnGameOver()
    {
        m_EndScoreTxt.text = "Your Score : " + m_ScoreTxt.text;  
    }
}
