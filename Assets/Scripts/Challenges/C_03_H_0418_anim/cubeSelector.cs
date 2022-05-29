using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Attached to child "Cube" in prefab CubeContainer
/// 
/// Detect the cube was clicked
/// Perform explosion animation
/// Instantiate debris
/// Animate debris deterioration
/// Video shows the entire animation happening
/// </summary>

public class cubeSelector : MonoBehaviour
{
    [SerializeField] private MeshRenderer m_Renderer;
    [SerializeField] int m_numberOfDebris = 2;
    [SerializeField] GameObject m_debrisPrefab;


    private void OnMouseDown()
    {
        //Detects the mouse was clicked on cube
        StartExplosion();
    }


    //Instantiate Debris smaller cubes
    private void StartExplosion()
    {

        //GetComponent<MeshRenderer>().enabled = false;
        Vector3 minBound = m_Renderer.bounds.min;
        Vector3 maxBound = m_Renderer.bounds.max;
        Vector3 finalBounds = maxBound - minBound;
        m_Renderer.enabled = false;

        //Define scale and aligment offset for each debris
        float alignmentOffset = 1 / (m_numberOfDebris * 2f);
        Vector3 debrisScale = new Vector3(1f / m_numberOfDebris, 1f / m_numberOfDebris, 1f / m_numberOfDebris);


        //Create cubic grid with all cubes - use .99f since we dont want another cube at 1
        for (float x = 0; x < finalBounds.x; x += 1f / m_numberOfDebris)
        {
            for (float y = 0; y < finalBounds.y; y += 1f / m_numberOfDebris)
            {
                for (float z = 0; z < finalBounds.z; z += 1f / m_numberOfDebris)
                {
                    float posx = x + alignmentOffset + minBound.x;
                    float posy = y + alignmentOffset + minBound.y;
                    float posz = z + alignmentOffset + minBound.z;
                    GameObject currentInstance = Instantiate(m_debrisPrefab, new Vector3
                        (posx, posy, posz), transform.rotation);
                    currentInstance.transform.localScale = debrisScale;
                    
                    //Activate each cube animation.
                    currentInstance.GetComponent<debrisExplosion>().CubeActivated(transform.position, m_Renderer);


                }
            }
        }

    }

}
