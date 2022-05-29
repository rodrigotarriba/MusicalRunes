using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Detects the submit button was clicked
///Gathers information from the sign-up fields
///Stores information using PlayerPrefs
///Pre - fills sign - up fields with the stored information
/// </summary>
/// 

public class easyChInputSaver : MonoBehaviour
{
    [SerializeField] GameObject[] m_inputFields;

    private void Awake()
    {
        //Check if each key exist - if they do, retrieve and prefill input text.
        foreach (var input in m_inputFields)
        {
            string name = input.name;
            if (PlayerPrefs.HasKey(name))
            {
                //If key exist populate areas
                input.GetComponent<TMP_InputField>().text = PlayerPrefs.GetString(name);
            }
        }

    }

    public void Submitted()
    {
        //Save the name of each input field, along with their text field value in PlayerPrefs.
        foreach (var input in m_inputFields)
        {
            PlayerPrefs.SetString(input.name, input.GetComponent<TMP_InputField>().text);
        }
    }
}

   
   


