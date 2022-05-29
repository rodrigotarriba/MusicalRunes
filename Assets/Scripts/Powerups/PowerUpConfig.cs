using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MusicalRunes;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "new PowerUp Config", menuName = "Configs/Power Up")] 

public class PowerUpConfig: ScriptableObject
{
    public PowerUpType m_powerUpType;

    public bool m_Upgradeable;
    public Sprite m_runeImage;
    // We dont need these anymore, since we added a reference to the translated dictionaries
    //public string m_powerUpName;
    //[TextArea] public string m_description;    

    public string m_powerUpNameID;
    public string m_descriptionID;
    public string m_powerUpName => Localization.s_currentLocalizationTable[m_powerUpNameID];
    public string m_description => Localization.s_currentLocalizationTable[m_descriptionID];
}
