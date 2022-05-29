using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

/// <summary>
/// Attach this to the GameManager.
/// User will click on button and this will
/// tell us if they clicked on the right button
/// </summary>
/// 


public class RuneSelector : MonoBehaviour
{
    [SerializeField] private GameObject m_announcerText;
    [SerializeField] private Button[] m_allButtons;
    [SerializeField] private AudioSource m_as;
    [SerializeField] private GameManager m_GMScript; //we can remove this
    [SerializeField] private int m_maxLives;
    [SerializeField] Image m_timeImage;

    [HideInInspector] public int[] m_currentRuneSequence = new[] { 1, 2, 3, 4 };
    public int m_currentIndex = 0;
    private float myTimer;


    public void Start()
    {
        m_GMScript.m_currentLives.text = m_maxLives.ToString();
    }

    public void OnRuneActivated(int clickedIndex)
    {
        StopCoroutine("RuneTimer");

        //Method activated by button when rune is clicked, button sends their index per their inspector.

        //Detect if the sequence has been completed already - empties the current count.
        if (m_currentIndex >= m_currentRuneSequence.Length)
        {
            m_currentIndex = 0;
            return;
        }


        //Detect whether the index touched is the same as the next index in the array.
        if (m_currentRuneSequence[m_currentIndex] == clickedIndex)
        {
            CorrectSelected();
        }
        else
        {
            FailedRune("wrongRune");
        }



    }

    private void CorrectSelected()
    {

        m_announcerText.GetComponent<TextMeshProUGUI>().text = Localization.s_currentLocalizationTable["AnnouncerPlayerTurn"];

        // When the correct rune was selected
        m_currentIndex++;
        if(myTimer > 1.5)
        {
            m_GMScript.AddScore(20);
            m_GMScript.m_addedScore.text = "+20!";
        }
        else
        {
            m_GMScript.AddScore(10);
            m_GMScript.m_addedScore.text = "+10!";
        }
        StartCoroutine("RuneTimer");

        //Logic
        if (m_currentIndex >= m_currentRuneSequence.Length)
        {
            m_as.Play();
            StopCoroutine("RuneTimer");
            SequenceCompleted();
        }

    }



    private void FailedRune(string typeOfFail)
    {
        
        if(typeOfFail == "timesUp")
        {
            m_announcerText.GetComponent<TextMeshProUGUI>().text = Localization.s_currentLocalizationTable["AnnouncerFailedByTimeout"];
        }
        
        if(typeOfFail == "wrongRune")
        {
            m_announcerText.GetComponent<TextMeshProUGUI>().text = Localization.s_currentLocalizationTable["AnnouncerFailedChoice"];
        }

        LosingALife();
    }
    
    
    private void LostGame()
    {

        m_currentIndex = 0;
        //Debug.Log($"{m_currentIndex}");
        StartCoroutine(RestartingRoutine());
    }


    private void LosingALife()
    {
        m_maxLives -= 1;
        m_GMScript.m_currentLives.text = m_maxLives.ToString();
        if (m_maxLives <= 0)
        {
            LostGame();
        }

    }

    private IEnumerator RuneTimer()
    {
        myTimer = 5.0f;

        while (myTimer > 0f)
        {
            myTimer -= Time.deltaTime;
            m_timeImage.fillAmount = myTimer / 5.0f;
            Debug.Log(myTimer);
            yield return null;
        }

        if (myTimer <= 0f)
        {
            FailedRune("timesUp");
        }
        
    }

    // CoinsAmount += combo ? comboCoinsPerRune : coinsPerRune; 


    private IEnumerator RestartingRoutine()
    {
        //Make buttons not interactable
        foreach (var go in m_allButtons)
        {
            go.interactable = false;
        }
        m_announcerText.GetComponent<TextMeshProUGUI>().text = Localization.s_currentLocalizationTable["AnnouncerFailedByRuneChoice"];

        yield return new WaitForSeconds(1);

        m_announcerText.GetComponent<TextMeshProUGUI>().text = "3";
        yield return new WaitForSeconds(1);

        m_announcerText.GetComponent<TextMeshProUGUI>().text = "2";
        yield return new WaitForSeconds(1);

        m_announcerText.GetComponent<TextMeshProUGUI>().text = "1";
        yield return new WaitForSeconds(1);

        m_announcerText.GetComponent<TextMeshProUGUI>().text = Localization.s_currentLocalizationTable["AnnouncerPlayerTurn"];

        yield return null;

        foreach (var go in m_allButtons)
        {
            go.interactable = true;
        }

        yield return null;
    }


    private void SequenceCompleted()
    {
        StopCoroutine(RuneTimer());
        m_currentIndex = 0;
        m_GMScript.AddScore(100);
        m_GMScript.m_addedScore.text = "+100!!!!!";
        return;
        //throw new NotImplementedException();
    }



}

