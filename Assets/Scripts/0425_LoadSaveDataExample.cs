using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LoadSaveDataExample : MonoBehaviour
{
    public SaveData data;

    public void OnApplicationQuit() //saving
    {
        SaveData data = new SaveData();
        data.highScore = "10";
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.dataPath + "/SaveData.json", json);
        //PlayerPrefs.SetString("Highscore", "True"); //alternative
    }

    private void Awake() //find the file and load from it
    {
        //if(PlayerPrefs.HasKey("Highscore"))
        if (File.Exists(Application.dataPath + "/SaveData.json"))
        {
            string json = File.ReadAllText(Application.dataPath + "/SaveData.json");
            SaveData data = JsonUtility.FromJson<SaveData>(json);
        }
        


    }

}