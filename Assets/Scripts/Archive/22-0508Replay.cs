using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Replay : MonoBehaviour
{
    [SerializeField] private RuneSelector m_RSScript;
    [SerializeField] private ShowHintPowerUp m_ShowHintScript;
    [SerializeField] private Button m_thisButton;

    public void Awake()
    {
        m_thisButton.interactable = false;
    }


    public void Update()
    {
        if (m_RSScript.m_currentIndex >= 2)
        {
            m_thisButton.interactable = true;
        }
        else m_thisButton.interactable = false;


    }
    public void ReplayBtnClicked()
    {
        m_RSScript.m_currentIndex = 0;
        m_thisButton.interactable = false;
        foreach(var btnImg in m_ShowHintScript.m_btnImgs)
        {
            btnImg.color = Color.white;
        }
    }

}
