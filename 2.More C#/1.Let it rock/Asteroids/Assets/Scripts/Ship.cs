using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ship Thruster
/// </summary>

public class Ship : MonoBehaviour
{
    Rigidbody2D rb2d;
    Vector2 thrustDirection;
    const float ThrustForce = 15;
    const float RotateDegreesPerSecond = 50;
    float colliderRadius;
    float rotationInput;
    float eulerZ;
    Vector3 eulerAngles;

    // Start is called before the first frame update
    void Start()
    {   
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // calculate rotation amount and apply rotation
        eulerZ = eulerAngles.z * Mathf.Deg2Rad;
        rotationInput = Input.GetAxis("Rotate");
        float rotationAmount = RotateDegreesPerSecond * Time.deltaTime;
        thrustDirection = new Vector2(Mathf.Cos(eulerZ),Mathf.Sin(eulerZ));
        if (rotationInput < 0) 
        {
            rotationAmount *= -2;
            transform.Rotate(Vector3.forward, rotationAmount);
            eulerAngles = transform.eulerAngles;
        }
        else if(rotationInput > 0)
        {
            rotationAmount *= -2;
            transform.Rotate(-Vector3.forward, rotationAmount);
            eulerAngles = transform.eulerAngles;
        }
    }

    // Update for physics based work
    void FixedUpdate()
    {
        if(Input.GetAxis("Thrust")>0)
        {
            rb2d.AddForce(ThrustForce*thrustDirection, ForceMode2D.Force);
        }
    }
}
