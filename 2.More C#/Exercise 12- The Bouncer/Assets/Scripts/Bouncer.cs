using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    int health = 100;
    SpriteRenderer srender;
    Color color;

    // Start is called before the first frame update
    void Start()
    {
        srender= GetComponent<SpriteRenderer>();

        // apply impulse force to get game object moving
        const float MinImpulseForce = 3f;
        const float MaxImpulseForce = 5f;
        float angle = Random.Range(0, 2 * Mathf.PI);
        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
        GetComponent<Rigidbody2D>().AddForce(direction * magnitude,ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Destroys the bouncer on health 0
    /// </summary>
    /// <param name="coll">collision info</param>
    void OnCollisionEnter2D(Collision2D coll)
    {
        Color color = srender.color;
        color.a -= 0.1f;
        srender.color = color;
        health-=10;
        Debug.Log("Health decreased"+ health);
        if(health<=0)
        Destroy(gameObject);   
    }
}
