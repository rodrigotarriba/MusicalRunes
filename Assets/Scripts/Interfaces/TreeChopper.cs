using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeChopper : MonoBehaviour, IHurtable
{
    void OnTriggerEnter(Collider other)
    {
        // First we check if the object the treechopper is colliding with has a IHurtable interface
        IHurtable hurtable = other.GetComponent<IHurtable>();


        // If it does, then activate the interface
        if (hurtable != null)
        {
            GetHit();
        }
    }

    public void GetHit()
    {
        return;
    }
}
