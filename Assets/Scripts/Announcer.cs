using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Announcer : MonoBehaviour
{
    [SerializeField] [Range(0f, 1f)] private float m_bounceAmplitude = 0.01f;
    [SerializeField] [Range(-2f, 2f)] private float m_bounceFrequency = 0.01f;
    [SerializeField] public TextMeshProUGUI m_textMeshPro;


    private void Start()
    {
        m_textMeshPro.text = Localization.s_currentLocalizationTable["AnnouncerListen"];
    }

    void Update()
    {

        transform.localScale = Vector3.one + Vector3.one * Mathf.Sin(Time.time * m_bounceFrequency) * m_bounceAmplitude;
    }


}
