using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    public float currentTime;
    public bool countdownStart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (countdownStart && currentTime > 0)
            currentTime -= Time.deltaTime;


    }
}
