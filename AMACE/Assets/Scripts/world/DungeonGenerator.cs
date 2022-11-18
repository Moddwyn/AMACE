using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    public int roomCount;
    public Transform startingAnchor;
    public Transform[] hallwayPrefabs;
    public Transform[] roomPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void roomGenerator()
    {
        if (startingAnchor == null)
            return;
        Transform nextAnchor = startingAnchor;
        for(int i = 0; i < roomCount; i++)
        {

        }
    }


}
