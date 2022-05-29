using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pendulumWithSin : MonoBehaviour
{
    [SerializeField] float m_cycleDuration;
    [SerializeField] float m_maxAngle;
    private float m_timer;
    private float m_initialTime;
    private float m_finalTime;
    private float m_cyclet;
    private float m_newAngle;
    private Quaternion m_newAngleQuats;
    private Quaternion m_startingRot;

    /// <summary>
    /// create a timer 
    /// timer flips the target vector when it completes
    /// rotate Slerp towards the other vector
    /// 
    /// </summary>



    // Start is called before the first frame update
    void Start()
    {
        //Restart timers and rotation start point
        m_initialTime = Time.time;
        m_finalTime = m_initialTime + m_cycleDuration;
        Quaternion m_startingRot = Quaternion.Euler(0, 0, 0);
        transform.rotation = m_startingRot;

    }

    void Update()
    {
        m_timer = 1 - ((m_finalTime - Time.time) / m_cycleDuration);

        //create timer
        if (m_timer > 1)
        {
            m_finalTime = Time.time + m_cycleDuration;
        }

        //know current rotation t (sinus)
        m_cyclet = Mathf.Sin(m_timer * 2 * Mathf.PI);

        //get new angle
        m_newAngle = m_maxAngle * m_cyclet;

        //convert angles to quaternions
        Quaternion m_newAngleQuats = Quaternion.Euler(0, 0, m_newAngle);

        //rotate at the new quat angle
        transform.rotation = m_newAngleQuats;
    }
}

