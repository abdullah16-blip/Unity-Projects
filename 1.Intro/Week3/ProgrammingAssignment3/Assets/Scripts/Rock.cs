using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A rock
/// </summary>
public class Rock : MonoBehaviour
{
	/// <summary>
	/// Use this for initialization
	/// </summary>
	void Start()
	{
        // apply impulse force to get game object moving
        const float MinImpulseForce = 1f;
        const float MaxImpulseForce = 2f;
        float angle = Random.Range(0, 2 * Mathf.PI);
        Vector2 direction = new Vector2(
            Mathf.Cos(angle), Mathf.Sin(angle));
        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
        GetComponent<Rigidbody2D>().AddForce(
            direction * magnitude,
            ForceMode2D.Impulse);		
	}

    // I used m_Renderer.isInvisible() method so that the object destroys when leaving rendering 
    // position of camera
    
    /// <summary>
    /// Called when the rock becomes invisible
    /// </summary>
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
