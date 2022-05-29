using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
/// <summary>
/// This script was previously attached to Canvas - it would accept the Coins>Text elements and a click event. 
/// Its a good example of testing events and how to invoke them.
/// </summary>

public class TestEvents : MonoBehaviour
{
    [SerializeField] UnityEvent m_click;
    [SerializeField] GameObject m_coinText;

    private void Update()
    {
        //This is how you invoke a UnityEvent:
        //if (Input.GetKeyDown(KeyCode.Mouse0))
        //{
        //    m_click.Invoke();
        //}
    }

    public void DecreaseCoins()
    {
        string fromcomp = m_coinText.GetComponent<TextMeshProUGUI>().text;
        int m_currentScore = int.Parse(fromcomp);
        m_currentScore--;
        m_coinText.GetComponent<TextMeshProUGUI>().text = $"{m_currentScore}";
    }

    public void PlayASound(GameObject theRune)
    {
        theRune.GetComponent<AudioSource>().Play();
        DecreaseCoins();
    }
}


