using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Here a random Asteroid comes!
/// </summary>
public class Asteroid : MonoBehaviour
{
    GameObject clone;

    Vector3 scale;
    float asteroidRadius;

    [SerializeField]
    Sprite GreenRock;
    [SerializeField]
    Sprite MagentaRock;
    [SerializeField]
    Sprite WhiteRock;

    // Start is called before the first frame update
    void Start()
    {
        asteroidRadius = GetComponent<CircleCollider2D>().radius;

        // set random sprite for new Rock
		SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
		int spriteNumber = Random.Range(0, 3);
		if (spriteNumber == 0)
        {
			spriteRenderer.sprite = GreenRock;
		}
        else if (spriteNumber == 1)
        {
			spriteRenderer.sprite = MagentaRock;
		}
        else
        {
			spriteRenderer.sprite = WhiteRock;
        }
    }

     /// <summary>
    /// Starts the asteroid moving in the given direction
    /// </summary>
    /// <param name="direction">direction for the asteroid to move</param>
    /// <param name="position">position for the asteroid</param>
    public void Initialize(Direction direction, Vector3 position)
    {
        // set asteroid position
        transform.position = position;

        // set random angle based on direction
        float angle;
        float randomAngle = Random.value * 30f * Mathf.Deg2Rad;
        if (direction == Direction.Up)
        {
            angle = 75 * Mathf.Deg2Rad + randomAngle;
        }
        else if (direction == Direction.Left)
        {
            angle = 165 * Mathf.Deg2Rad + randomAngle;
        }
        else if (direction == Direction.Down)
        {
            angle = 255 * Mathf.Deg2Rad + randomAngle;
        }
        else
        {
            angle = -15 * Mathf.Deg2Rad + randomAngle;
        }

        StartMoving(angle);
    }

    /// <summary>
    /// Gets asteroids moving!
    /// </summary>
    /// <param name="angle"></param>
    public void StartMoving(float angle)
    {
        // apply impulse force to get asteroid moving
        const float MinImpulseForce = 1f;
        const float MaxImpulseForce = 1.5f;
        Vector2 moveDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
        GetComponent<Rigidbody2D>().AddForce(moveDirection * magnitude,ForceMode2D.Impulse);
    }

    /// <summary>
    /// Destroys the ship on collision with an asteroid
    /// </summary>
    /// <param name="coll">collision info</param>
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Bullet"))
        {
            AudioManager.Play(AudioClipName.AsteroidHit);
            scale = gameObject.transform.localScale;
            scale.x = scale.x /2;
            scale.y = scale.y /2;
            gameObject.transform.localScale = scale;
            asteroidRadius = asteroidRadius/2;
            GetComponent<CircleCollider2D>().radius = asteroidRadius;
            clone = Instantiate<GameObject>(gameObject);
            Asteroid script = clone.GetComponent<Asteroid>();
            script.StartMoving(Random.Range(0, 2 * Mathf.PI));
            Destroy(coll.gameObject);
            if(scale.x < 0.5)
                Destroy(gameObject);
        }
    }
}
