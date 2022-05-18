using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    const float lifespan = 1f;
    Timer deathTimer;
    
    public void ApplyForce(Vector2 moveDirection)
    {
        const float magnitude = 15f;
        GetComponent<Rigidbody2D>().AddForce(moveDirection * magnitude,ForceMode2D.Impulse);
    }

    // Start is called before the first frame update
    void Start()
    {
        // create and start timer
		deathTimer = gameObject.AddComponent<Timer>();
		deathTimer.Duration = lifespan;
		deathTimer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        // kill bullet if death timer finished
		if (deathTimer.Finished)
        {
			Destroy(gameObject);
		}
    }
}
