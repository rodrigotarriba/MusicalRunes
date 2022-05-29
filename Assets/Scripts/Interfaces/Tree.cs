using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tree : MonoBehaviour, IHurtable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetHit()
    {
        Destroy(gameObject);
    }
}
