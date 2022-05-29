using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Make the cube move back and forth between multiple points, moving at a different velocity on each segment.
/// The position of the GameObject and its velocity on each segment must be configurable in the inspector.
/// </summary>
/// 

public class TestBehaviour : MonoBehaviour
{
    [SerializeField] Vector3[] m_cubePos;
    [SerializeField] float m_minSped;
    [SerializeField] float m_maxSpeed;


    private int m_posOne;
    private int m_posTwo;
    private float m_currentSpeed;
    private float m_lerp;
    private float m_finalTime;
    private float m_sectionDuration;


    private void Start()
    {
        //base values at position 0
        m_posOne = 0;
        m_posTwo = m_posOne + 1;
        m_currentSpeed = Random.Range(m_minSped, m_maxSpeed);
        m_sectionDuration = Vector3.Distance(m_cubePos[m_posOne], m_cubePos[m_posTwo]) / m_currentSpeed;
        m_finalTime = Time.time + m_sectionDuration;
        m_lerp = 0f;
    }

    void Update()
    {
        
        //Indicate next positions for movement + restart animation values
        if (m_lerp >= 1)
        {
            m_posOne++;
            m_posTwo++;
            Debug.Log($"{m_posOne} is going now");

            if (m_posOne == m_cubePos.Length - 1)
            {
                m_posTwo = 0;
                //Debug.Log("Here");
            }
            
            if (m_posOne > m_cubePos.Length - 1)
            {
                m_posOne = 0;
                m_posTwo = m_posOne + 1;
            }
            
            //Starting values from one point to the next
            m_currentSpeed = Random.Range(m_minSped, m_maxSpeed);
            m_sectionDuration = Vector3.Distance(m_cubePos[m_posOne], m_cubePos[m_posTwo]) / m_currentSpeed;
            m_finalTime = Time.time + m_sectionDuration;
            m_lerp = 0f;
            Debug.Log($"{m_sectionDuration} ");
        }

        //Move element along the vector at the indicated speed
        m_lerp = 1f - ((m_finalTime - Time.time) / m_sectionDuration);
        transform.position = Vector3.Lerp(m_cubePos[m_posOne], m_cubePos[m_posTwo], m_lerp);



    }



    
}

