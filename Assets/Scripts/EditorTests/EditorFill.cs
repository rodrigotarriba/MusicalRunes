using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]

public class EditorFill : MonoBehaviour
{
    public UseSomeLists m_USLScript;
    
    // Start is called before the first frame update
    void OnDisable()
    {
        m_USLScript.m_boxColliders = GetComponentsInChildren<BoxCollider>();
    }


}
