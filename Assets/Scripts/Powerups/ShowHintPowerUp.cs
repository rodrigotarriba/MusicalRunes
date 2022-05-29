using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ShowHintPowerUp : PowerUp
{
    [SerializeField] public Image[] m_btnImgs;
    //relies on knowing which the current index and sequence is - values currently in our rune selector - we need to make those public.
    [SerializeField] private RuneSelector m_RSScript;
    //THis could be a singleton instead of referencing for it.
    private int[] m_correctSequence;

    private void Awake()
    {
        m_correctSequence = m_RSScript.m_currentRuneSequence;

    }

    public override void OnPowerUpClick()
    {
        base.OnPowerUpClick(); //allowing it to keep doing what 
        
        m_btnImgs[m_correctSequence[m_RSScript.m_currentIndex] - 1].color = Color.green;

    }

}
