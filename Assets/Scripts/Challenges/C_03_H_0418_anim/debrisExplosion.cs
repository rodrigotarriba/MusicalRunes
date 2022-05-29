using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Attached to Debris prefab 
/// which is instanced by Cube Selector
/// when activated
/// </summary>


public class debrisExplosion : MonoBehaviour
{
    [SerializeField] [Range(1f, 10f)] public float m_explosionForce;
    [SerializeField] [Range(.1f, 10f)] public float m_deaccelerationRate;
    private Vector3 explodingDirection;
    private float m_currentImpactSpeed;
    private float m_currentFallingSpeed;
    private float m_gravitySpeed = .1f;

    public void CubeActivated(Vector3 expOrigin, MeshRenderer instantiatorVis)
    {
        //When activated, detects vector from origin of original exploding Cube and location of this debris prefab in order to explode outwards
        explodingDirection = transform.position - expOrigin;
        explodingDirection.Normalize();
        StartCoroutine(DebrisExploding(instantiatorVis));

    }


    IEnumerator DebrisExploding(MeshRenderer instantiatorVis)
    {
        yield return StartCoroutine(ExplodeAndFall());

        //Object gets destroyed once out of frame
        Destroy(gameObject);

        //Mesh renderer in instantiator object is changed to on.
        if (!instantiatorVis.enabled)
        {
            instantiatorVis.enabled = true;
        }

        yield return null;

    }
    
    IEnumerator ExplodeAndFall()
    {
        m_currentImpactSpeed = m_explosionForce;
        m_currentFallingSpeed = 0f;

        ////Animate explosion and gravity effect while still in frame
        while (transform.position.y > -30)
        {
            //projectile speed diminishes every frame
            transform.Translate(explodingDirection * m_currentImpactSpeed * Time.deltaTime);
            m_currentImpactSpeed -= (m_deaccelerationRate * Time.deltaTime);

            //falling speed increases every frame
            transform.Translate(Vector3.down * m_currentFallingSpeed);
            m_currentFallingSpeed += m_gravitySpeed * Time.deltaTime;
            yield return null;
        }
    }

}
