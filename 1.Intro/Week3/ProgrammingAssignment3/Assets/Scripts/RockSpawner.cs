using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A rock spawner
/// </summary>
public class RockSpawner : MonoBehaviour
{
    // needed for spawning
	[SerializeField]
	GameObject prefabRock;

    // saved for efficiency	
    [SerializeField]
	Sprite greenrock;
    [SerializeField]
    Sprite magentarock;
    [SerializeField]
    Sprite whiterock;

	// spawn control
	Timer spawnTimer;

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
		// create and start timer
		spawnTimer = gameObject.AddComponent<Timer>();
		spawnTimer.Duration = 1;
		spawnTimer.Run();
	}

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
		// check for time to spawn a new rock
		if (spawnTimer.Finished && GameObject.FindGameObjectsWithTag("Rock").Length <3)
        {
			SpawnRock();

			// change spawn timer duration and restart
			spawnTimer.Duration = 1;
			spawnTimer.Run();
		}
	}
	
	/// <summary>
	/// Spawns a new rock at the center
	/// </summary>
	void SpawnRock()
	{
		// create new rock at the center
        GameObject rock = Instantiate(prefabRock) as GameObject;
        rock.transform.position = Vector3.zero;

		// set random sprite for new Rock
		SpriteRenderer spriteRenderer = rock.GetComponent<SpriteRenderer>();
		int spriteNumber = Random.Range(0, 3);
		if (spriteNumber == 0)
        {
			spriteRenderer.sprite = greenrock;
		}
        else if (spriteNumber == 1)
        {
			spriteRenderer.sprite = magentarock;
		}
        else
        {
			spriteRenderer.sprite = whiterock;
		}
	}
}