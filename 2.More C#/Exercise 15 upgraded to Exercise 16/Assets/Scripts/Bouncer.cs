using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    int health = 100;
    SpriteRenderer srender;
    Color color;

    // bouncing support
    HUD hud;
    const int bounce = 1;

    //audio support
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        // apply impulse force to get game object moving
        const float MinImpulseForce = 3f;
        const float MaxImpulseForce = 5f;
        float angle = Random.Range(0, 2 * Mathf.PI);
        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
        GetComponent<Rigidbody2D>().AddForce(direction * magnitude,ForceMode2D.Impulse);

        // save a reference to the hud
        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();

        //save a reference to the AudioSource
        audioSource = GetComponent<AudioSource>();
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
        Debug.Log("Boing!");
        hud.AddBounce(bounce);
        audioSource.Play();
    }

    void OnBecameInvisible() 
    {
        Destroy(gameObject);
    }
}
