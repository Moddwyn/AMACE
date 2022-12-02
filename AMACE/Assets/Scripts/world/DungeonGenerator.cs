using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    public Transform mapHolder;
    public int roomCount;
    public Transform startingAnchor;
    public Transform[] hallwayPrefabs;
    public Transform[] roomPrefabs;
    public Transform[] deadroomPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        roomGenerator();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void roomGenerator()
    {
        if (startingAnchor == null)
            return;
        if (mapHolder == null)
            return;
        Transform nextAnchor = startingAnchor;
        for(int i = 0; i < roomCount; i++)
        {
            int RandHall = Random.Range(0, hallwayPrefabs.Length);
            Transform SpawnHallway = Instantiate(hallwayPrefabs[RandHall], nextAnchor.position, Quaternion.Euler(nextAnchor.rotation.eulerAngles));
            nextAnchor = SpawnHallway.GetChild(0);

            int RandRoom = Random.Range(0, roomPrefabs.Length);
            Transform SpawnRoom = Instantiate(roomPrefabs[RandRoom], nextAnchor.position, Quaternion.Euler(nextAnchor.rotation.eulerAngles));
            Transform[] NextExit = SpawnRoom.GetComponentsInChildren<Transform>().Where(x => x.tag == "Anchor").ToArray();
            int RandExit = Random.Range(0, NextExit.Length);
            nextAnchor = NextExit[RandExit];

            GameObject NewRoom = new GameObject("Room " + (mapHolder.childCount + 1));
            NewRoom.transform.SetParent(mapHolder);
            SpawnHallway.SetParent(NewRoom.transform);
            SpawnRoom.SetParent(NewRoom.transform);
        }
    }


}
