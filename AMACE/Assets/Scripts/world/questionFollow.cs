using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class questionFollow : MonoBehaviour
{
    Transform Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Player == null)
            Player = GameObject.FindGameObjectWithTag("Player").transform;
        transform.LookAt(Player);
    }
}
