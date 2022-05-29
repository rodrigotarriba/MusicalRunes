using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinLightManager : MonoBehaviour
{
    [SerializeField] private GameObject[] m_spinLights; //My spin Light Game Objects

    private void Start()
    {
        StartCoroutine(FlashLights());
    }


    IEnumerator FlashLights()
    {
        while (true)
        {

            yield return new WaitForSeconds(0.5f);
            //iterate through the spinlights and iterate on and off

            foreach (GameObject go in m_spinLights)
            {
                go.SetActive(!go.activeSelf);
            }

        }
    }
}
