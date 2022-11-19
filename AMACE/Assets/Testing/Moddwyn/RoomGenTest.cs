using System.Collections;
using System.Linq;
using UnityEngine;

public class RoomGenTest : MonoBehaviour
{
    public int roomCount;
    public bool spawnAtStart = true;

    [Space(20)]
    public Transform startingAnchor;
    public Transform mapHolder;

    [Space(20)]
    public Transform[] hallwayPrefabs;
    public Transform[] roomPrefabs;
    public Transform[] deathRoomPrefabs;

    void Start()
    {
        if(spawnAtStart) Generate();
    }

    public void Generate()
    {
        StopCoroutine(GenerateRoom(roomCount));
        StartCoroutine(GenerateRoom(roomCount));
    }

    public IEnumerator GenerateRoom(int rooms)
    {
        if(startingAnchor == null) yield break;;
        if(mapHolder == null) yield break;

        yield return new WaitUntil(EmptyHolder);

        Transform nextAchor = startingAnchor;
        for (int i = 0; i < rooms; i++)
        {
            int randHallway = Random.Range(0, hallwayPrefabs.Length);
            Transform spawnHallway = (Transform)Instantiate(hallwayPrefabs[randHallway], nextAchor.position, Quaternion.Euler(nextAchor.rotation.eulerAngles));
            nextAchor = spawnHallway.GetChild(0);

            int randRoom = Random.Range(0, roomPrefabs.Length);
            Transform spawnRoom = (Transform)Instantiate(roomPrefabs[randRoom], nextAchor.position, Quaternion.Euler(nextAchor.rotation.eulerAngles));
            
            Transform[] nextExits = spawnRoom.GetComponentsInChildren<Transform>().Where(x=>x.tag == "Anchor").ToArray();
            int randCorrectExit = Random.Range(0, nextExits.Length);

            for (int j = 0; j < nextExits.Length; j++)
            {
                if(j != randCorrectExit)
                {
                    nextAchor = nextExits[j];
                    Transform spawnDeath = (Transform)Instantiate(deathRoomPrefabs[Random.Range(0, deathRoomPrefabs.Length)],
                                            nextAchor.position, Quaternion.Euler(nextAchor.rotation.eulerAngles));
                    spawnDeath.parent = spawnRoom;
                }
            }
            nextAchor = nextExits[randCorrectExit];

            GameObject newRoom = new GameObject("Room " + (mapHolder.childCount + 1));
            newRoom.transform.parent = mapHolder;
            spawnHallway.parent = newRoom.transform;
            spawnRoom.parent = newRoom.transform;
        }
    }

    bool EmptyHolder()
    {
        while(mapHolder.childCount > 0)
        {
            foreach (Transform child in mapHolder) 
            {
                # if UNITY_EDITOR
                    DestroyImmediate(child.gameObject);
                #else
                    Destroy(child.gameObject);
                #endif
            }
        }
        return true;
    }
}
