using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// This was an exercise attached to GameManager
/// Takes an array and randomizes the highest value within the array's initial max and min values, every three seconds.
/// </summary>
public class arrayLogger : MonoBehaviour
{
    private int[] m_arrayToRandomize = 
        //{ 0, 1, 2, 3};
        // {3, 2, 1, 0};
        {99999999, 100000, 2300, 1000, 30300, -293, -39999, 232, 758548};
        // {-1000, -999, -998, -997, -2, -1, 0, 1, 2, 997, 998, 999, 1000};
        // {};
        // {1};


    private float m_timer;
    private int m_highValue;
    private int m_lowValue;
    private bool m_gameEnabled;

    void Start()
    {
        //guard clause - array must have at least 2 numbers
        if(m_arrayToRandomize.Length <= 1)
        {
            Debug.Log("This game requires more players!");
            m_gameEnabled = false;
            return;
        }

        //calculates 
        m_gameEnabled = true;
        m_highValue = Mathf.Max(m_arrayToRandomize);
        m_lowValue = Mathf.Min(m_arrayToRandomize);

        RandomizeHighestValue(m_arrayToRandomize, m_lowValue, m_highValue);

    }

    void Update()
    {
        //Only run array if game is enabled from start
        if (m_gameEnabled == false)
        {
            return;
        }
        

        m_timer += Time.deltaTime;

        // guard clause - Runs randomize highest value function after three seconds have passed
        if (m_timer >= 3.0)
        {
            RandomizeHighestValue(m_arrayToRandomize, m_lowValue, m_highValue);
            m_timer = 0;
        }
    }

    private void RandomizeHighestValue(int[] sortingArray, int lowVal, int highVal)
    {
        //grabs the index with the highest value from the given array if index is int
        int highestIndex = 0;
        for (int i = 0; i < sortingArray.Length; i++)
        {
            if(sortingArray[i] > sortingArray[highestIndex])
            {
                highestIndex = i;
            }
        }

        

        // logs highest index found 
        Debug.Log($"The highest value is {sortingArray[highestIndex]} at index {highestIndex}");


        //randomizes the number at the index found
        sortingArray[highestIndex] = Random.Range(lowVal, highVal);

        //prints the new array
        var m_tobeprinted = String.Join(", ", sortingArray);
        Debug.Log($"Current array is {{{m_tobeprinted}}}");
    }
}
