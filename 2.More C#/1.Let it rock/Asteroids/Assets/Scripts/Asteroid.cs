using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Here a random Asteroid comes!
/// </summary>
public class Asteroid : MonoBehaviour
{
    [SerializeField]
    Sprite GreenRock;
    [SerializeField]
    Sprite MagentaRock;
    [SerializeField]
    Sprite WhiteRock;

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

}
