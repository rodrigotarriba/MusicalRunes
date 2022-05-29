using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// 
/// </summary>


public class GameManager : MonoBehaviour
{
    //Variables
    public static GameManager s_instance; //You can reference this variable anywhere now.
    [SerializeField] private TextMeshProUGUI m_highScoreText;
    [SerializeField] private TextMeshProUGUI m_currentScoreText;
    [SerializeField] public TextMeshProUGUI m_addedScore;
    [SerializeField] public TextMeshProUGUI m_currentLives;
    private int m_currentScore = 0;
    private int m_highScore;
    //private string m_scoreKey = "HighScore";
    public SaveData data;
    private int m_completedSequences;
    [SerializeField] private int m_levelGoal;
    private bool m_timerPlaying;

    private void Awake()
    {
        //Checks if there are no duplicate instances of this GameManager class
        if(s_instance == null)
        {
            s_instance = this;
        }
        else
        {
            Debug.LogError("multiple singleton instance");
        }

        
        //Checks if there is already a saved Json file - stores it under scoreData
        if(File.Exists(Application.dataPath + "/saveData.json"))
        {
            string jsonData = File.ReadAllText(Application.dataPath + "/saveData.json"); //
            SaveData data = JsonUtility.FromJson<SaveData>(jsonData);
            UpdateHighscore(int.Parse(data.highScore));
        }
    }

    private void Start()
    {
        m_timerPlaying = false;

    }






    public void UpdateHighscore(int points)
    {
        //Updates highScore variable and changes text in UI
        m_highScore = points;
        m_highScoreText.text = m_highScore.ToString();
    }

    public void UpdateHighscore2(int points)
    {
        //Updates highScore variable and changes text in UI
        m_highScore = points;
        m_highScoreText.text = m_highScore.ToString();
    }

    public void ChangeMyLanguage(string language)
    {
        switch (language)
        {
            case "English":
                Localization.s_currentLocale = Locale.en;
                break;

            case "Portuguese":
                Localization.s_currentLocale = Locale.pt;
                break;
        }
    }

    public void AddScore(int points)
    {
        //Adds points to the current score
        m_currentScore += points;
        m_currentScoreText.text = m_currentScore.ToString();



        //If current score is larger than the highest score, highscore gets updated.
        if (m_currentScore > m_highScore)
        {
            UpdateHighscore(m_currentScore);

        }

        //Increases no. of sequences completed
        m_completedSequences++;

        //If no. of sequences higher than levelGoal - add a new random rune to the system.

    }


    private void OnApplicationQuit()
    {

        if(m_currentScore >= m_highScore)
        {
            SaveData data = new SaveData();
            data.highScore = m_currentScore.ToString();
            string jsonData = JsonUtility.ToJson(data);
            File.WriteAllText(Application.dataPath + "/SaveData.json", jsonData);
        }



    }

}
