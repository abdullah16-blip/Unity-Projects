using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenTeddyBear : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 newscale = transform.localScale;
        newscale.y *= 4;
        transform.localScale = newscale;
    }
}
