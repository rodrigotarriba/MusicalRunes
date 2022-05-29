using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PowerUpUpgradePopup : MonoBehaviour
{
    public Image m_btnImage;
    public Button m_btn;
    public PowerUpConfig m_powerupConfig;
    
    // Start is called before the first frame update
    void Start()
    {
        Setup(m_powerupConfig);

    }

    public void Setup(PowerUpConfig powerupConfig)
    {
        m_btnImage.sprite = powerupConfig.m_runeImage;
        gameObject.name = powerupConfig.m_powerUpName;
        m_btn.interactable = powerupConfig.m_Upgradeable;
    }
}
