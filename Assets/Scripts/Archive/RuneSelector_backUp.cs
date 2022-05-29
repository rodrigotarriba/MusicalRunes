using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Attach this to the GameManager.
/// User will click on button and this will
/// tell us if they clicked on the right button
/// 
/// when we fail in the rune selector - we want the text to change to something else - 
/// Failed, 
/// Then delay
/// Then 3, 2, 1 
/// Go!
/// 
/// Buttons cant be clicked anymore in this time
/// </summary>
public class RuneSelector_backup : MonoBehaviour
{
    [SerializeField] private AudioSource m_as;
    private int[] m_currentRuneSequence = new[] { 0, 1, 2, 3 };
    private int m_currentIndex = 0;

    public void OnRuneActivated(int index)
    {
        if (m_currentIndex >= m_currentRuneSequence.Length) return;


        if (m_currentRuneSequence[m_currentIndex] == index)
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
        m_currentIndex = 0;
    }

    private void CorrectSelected()
    {
        m_currentIndex++;
        //m_as.Play();
        //Logic
        SequenceCompleted();
    }

    private void SequenceCompleted()
    {
        throw new NotImplementedException();
    }
}