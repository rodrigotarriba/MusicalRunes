using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinlight : MonoBehaviour
{
    //[SerializeField] [Range(0f, 360f)] private float m_rotationAmplitude = 0.01f;
    //[SerializeField] [Range(0, 20f)] private float m_rotationCycleFrequency = 0.01f;

    [SerializeField] [Range(-90f, 90f)] private float m_spinSpeed;


    // Update is called once per frame
    void Update()
    {

        transform.Rotate(Vector3.forward * m_spinSpeed * Time.deltaTime);

    }
}
