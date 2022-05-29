using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePlayerPosition : MonoBehaviour
{
    public GameObject player;
    public SerializedData serializedData;

    string savePositionData;
    string restorePosition;

    void Start()
    {
        serializedData = new SerializedData();
        RestorePosition();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SavePosition();
        }
    }

    void SavePosition()
    {
        serializedData.x = player.transform.position.x;
        serializedData.y = player.transform.position.y;
        serializedData.z = player.transform.position.z;
        savePositionData = JsonUtility.ToJson(serializedData);
        PlayerPrefs.SetString("PlayerPosition", savePositionData);
        Debug.Log(savePositionData);
    }

    void RestorePosition()
    {
        restorePosition = PlayerPrefs.GetString("PlayerPosition");
        SerializedData serializedData1 = JsonUtility.FromJson<SerializedData>(restorePosition);
        if (serializedData1 != null)
        {
            Vector3 position = new Vector3();
            position.x = serializedData1.x;
            position.y = serializedData1.y;
            position.z = serializedData1.z;
            player.transform.position = position;
        }
    }
}
