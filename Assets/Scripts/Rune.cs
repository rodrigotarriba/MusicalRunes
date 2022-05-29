using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This coroutine will move until we get a new task

public class Rune : MonoBehaviour
{
    //what color the rune is when you step on it
    [SerializeField] private Color m_activationColor;
    [SerializeField] private AudioSource m_audioSource;
    [SerializeField] private Image m_runeImage; //this one requires importing UnityEngine.UI;
    [SerializeField] private float m_colorTransitionDuration = .3f;

    private Coroutine m_coroutine;


    public void RuneClick()
    {
        //GetComponent<Button>().interactable = false;
        Debug.Log("rune click");
        StopAllCoroutines();
        StartCoroutine(ActivateRune());
    }

    private IEnumerator ActivateRune()
    {
        m_audioSource.Play();

        yield return LerpToColor(Color.white, m_activationColor);

        while (m_audioSource.isPlaying)
        {
            yield return null;
            //yield return new WaitForEndOfFrame(); //we wait until the end of frame to save on resources.
        }

        yield return LerpToColor(m_activationColor, Color.white);
    }




    private IEnumerator LerpToColor(Color start, Color end)
    {
        float elapsedTime = 0;
        float startTime = Time.time;

        while(elapsedTime < m_colorTransitionDuration)
        {
            m_runeImage.color = Color.Lerp(start, end, elapsedTime / m_colorTransitionDuration);
            elapsedTime = Time.time - startTime;
            yield return null;
        }
        yield return null;
    }
}

