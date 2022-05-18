using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowTeddyBear : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        Vector3 newscale = transform.localScale;
        newscale.x *= 4;
        newscale.y *= 4;
        transform.localScale = newscale;
    }
}
