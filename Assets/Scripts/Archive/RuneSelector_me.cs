using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Attach this to the GameManager.
/// User will click on button and this will tell us if they clicked on the right button.
/// </summary>
/// 


public class RuneSelector_me : MonoBehaviour
{
    [SerializeField] AudioSource m_as;
    [SerializeField] AudioSource m_asWinner;
    [SerializeField] GameObject m_coinsVal;

    private int[] currentRuneSequence = new[] { 0, 1, 2, 3 };
    private int currentIndex = 0;

    public void OnRuneActivated(int index)
    {
        if (currentIndex >= currentRuneSequence.Length) return;

        if (currentRuneSequence[currentIndex] == index)
        {
            CorrectSelected();
        }
        else
        {
            Failed();
        }
    }

    private void Failed()
    {
        currentIndex = 0;
    }

    private void CorrectSelected()
    {
        currentIndex++;
        m_as.Play();

        if(currentIndex >= currentRuneSequence.Length)
        {
            SequenceCompleted();
        }
    }

    private void SequenceCompleted()
    {
        m_asWinner.Play();
        int newValue = int.Parse(m_coinsVal.GetComponent<TextMeshProUGUI>().text) + 20;
        m_coinsVal.GetComponent<TextMeshProUGUI>().text = $"{newValue}";

        currentIndex = 0;
    }
}
