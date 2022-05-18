using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField]
    Text BounceText;
    int BounceNumber = 0;
    const string BouncePrefix = "Bounce: ";

    // Start is called before the first frame update
    void Start()
    {
        BounceText.text = BouncePrefix + BounceNumber.ToString();
    }

    public void AddBounce(int bounce)
    {
        BounceNumber += bounce;
        BounceText.text = BouncePrefix + BounceNumber.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
