using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public abstract class PowerUp : MonoBehaviour
{
    [SerializeField] private int m_coolDownDuration = 3;
    [SerializeField] private Image m_powerUpBtn;

    private float m_currentCoolDown;

    //if the cooldown gets to zero - then the isAvailable is true. 
    protected bool m_isAvailable => m_currentCoolDown <= 0;

    //image gets cropped after being clicked.

    private void Update()
    {
        if (m_currentCoolDown >= 0)
        {
            //Reduce the timer by the time taken in 1 frame
            m_currentCoolDown -= Time.deltaTime;
            //Debug.Log($"{m_currentCoolDown}");
            
            //We transition the botton to take a bit of time to fill - indication that it cant be used during that period.
            m_powerUpBtn.fillAmount = 1 - m_currentCoolDown / m_coolDownDuration;
                //1 - (elapsed time / maxcoolDownDuration) * scale.
           
        }
    }

    public virtual void OnPowerUpClick()
    {
        if (!m_isAvailable) return; 
        m_currentCoolDown = m_coolDownDuration;
    }


}
