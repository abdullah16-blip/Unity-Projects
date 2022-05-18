using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField]
    Text ScoreText;
    float elapsedseconds = 0;
    bool isrunning = true;
    const string TimePrefix = "Time: ";

    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = TimePrefix;
    }

    //Stops game timer
    public void StopGameTimer()
    {
        isrunning = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isrunning)
        {
            elapsedseconds += Time.deltaTime;
            ScoreText.text = TimePrefix + (int)elapsedseconds;
        }
    }
}
