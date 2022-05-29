using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class h_inputSaver : MonoBehaviour
{
    [SerializeField] GameObject[] m_inputFields;
    [SerializeField] GameObject[] m_profileTexts;
    [SerializeField] Dropdown m_dropMenu;
    [SerializeField] GameObject m_canvasSignIn;
    [SerializeField] GameObject m_canvasSignUp;
    [SerializeField] GameObject m_canvasProfile;
    private ChGameData m_gameData;


    public void Awake()
    {

        m_canvasProfile.SetActive(false);
        m_canvasSignUp.SetActive(false);

        //Check if PlayerPreffs has the settings object saved and retrieve, otherwise, create the game object and the list of players within, then convert to json and save to PlayerPrefs
        if (PlayerPrefs.HasKey("ChGameData"))
        {
            string json = PlayerPrefs.GetString("ChGameData");
            m_gameData = JsonUtility.FromJson<ChGameData>(json);
            
        }
        else
        {
            m_gameData = new ChGameData();
            m_gameData.playersData = new List<SavePlayer>();
            string json = JsonUtility.ToJson(m_gameData);
            PlayerPrefs.SetString("ChGameData", json);
        }
        
        //populate the login dropdown menu with the items of the list object
        PopulateDropDown();

    }
    

    public void PopulateDropDown()
    {
        //Populate dropdown with the playersData list saved in the retrieved GameData object. 
        List<string> m_currentPlayers = new List<string>();

        if(m_gameData.playersData.Count > 0)
        {

            foreach (SavePlayer i in m_gameData.playersData)
            {
                m_currentPlayers.Add(i.name);
                Debug.Log($"{m_currentPlayers.Count}");
            }
        }

        m_dropMenu.ClearOptions();
        m_dropMenu.AddOptions(m_currentPlayers);

    }



    public void ButtonSignIn()
    {

        //When a player is selected in the dropdown menu and submit is pressed - a new canvas shows stored info
        m_canvasSignUp.SetActive(false);
        m_canvasSignIn.SetActive(false);
        m_canvasProfile.SetActive(true);

        SavePlayer m_playerSelected = m_gameData.playersData[m_dropMenu.value];


        foreach(var input in m_profileTexts)
        {

            switch (input.name)
            {
                case "textName":
                    input.GetComponent<TextMeshProUGUI>().text = m_playerSelected.name;
                    break;
                case "textAge":
                    input.GetComponent<TextMeshProUGUI>().text = m_playerSelected.age;
                    break;
                case "textCity":
                    input.GetComponent<TextMeshProUGUI>().text = m_playerSelected.city;
                    break;
                case "textWeight":
                    input.GetComponent<TextMeshProUGUI>().text = m_playerSelected.weight;
                    break;
                default:
                    return;
            }
        }

    }



    //When clicking log out - main canvas appears
    public void ButtonLogOut()
    {

        m_canvasProfile.SetActive(false);
        m_canvasSignUp.SetActive(false);
        m_canvasSignIn.SetActive(true);
    }


    //When new player is clicked, signup canvas appears empty
    public void ButtonNewPlayer()
    {
        m_canvasSignIn.SetActive(false);
        m_canvasSignUp.SetActive(true);

    }


    //when create new player is clicked - a new user is stored
    public void ButtonCreateNewPlayer()
    {
        //Create a new instance of saveData with the appropiate information
        SavePlayer m_newPlayer = new SavePlayer();

        foreach (var input in m_inputFields)
        {
            string m_text = input.GetComponent<TMP_InputField>().text;

            switch (input.name)
            {
                case "playerName":
                    m_newPlayer.name = m_text;
                    break;
                case "playerAge":
                    m_newPlayer.age = m_text;
                    break;
                case "playerCity":
                    m_newPlayer.city = m_text;
                    break;
                case "playerWeight":
                    m_newPlayer.weight = m_text;
                    break;
                default:
                    return;
            }

            input.GetComponent<TMP_InputField>().text = "";
        }

        //Save new player info into the playerprefs class
        m_gameData.playersData.Add(m_newPlayer);

        //Save GameData again to Json and PlayerPrefs for backup
        string json = JsonUtility.ToJson(m_gameData);
        PlayerPrefs.SetString("ChGameData", json);

        //GO back to signup page
        m_canvasSignUp.SetActive(false);
        m_canvasSignIn.SetActive(true);
        PopulateDropDown();

    }


    //When go back is pressed, main canvas appears

    public void ButtonGoBack()
    {
        Debug.Log($"yes");
        foreach (var input in m_inputFields)
        {
            input.GetComponent<TMP_InputField>().text = "";
        }

        m_canvasProfile.SetActive(false);
        m_canvasSignUp.SetActive(false);
        m_canvasSignIn.SetActive(true);
    }







}
