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
    public int currentRoom = 0;
    // Start is called before the first frame update
    public static DungeonGenerator Instance;

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        roomGenerator();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
            goToNextRoom();
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
            int RandExit = Random.Range(0, 5);
            for (int j = 0; j < NextExit.Length; j++)
            {
                if (j != RandExit)
                {
                    nextAnchor = NextExit[j];
                    Transform spawnDeath = (Transform)Instantiate(deadroomPrefabs[Random.Range(0, deadroomPrefabs.Length)],
                                            nextAnchor.position, Quaternion.Euler(nextAnchor.rotation.eulerAngles));
                    spawnDeath.parent = SpawnRoom;
                }
            }
            nextAnchor = NextExit[RandExit];

            GameObject NewRoom = new GameObject("Room " + (mapHolder.childCount + 1));
            NewRoom.transform.SetParent(mapHolder);
            SpawnHallway.SetParent(NewRoom.transform);
            SpawnRoom.SetParent(NewRoom.transform);
            if(SpawnRoom.GetComponentInChildren<QuestionsManager>() != null)
            {
                SpawnRoom.GetComponentInChildren<QuestionsManager>().randExit = RandExit;
            }
            
        }
    }

    public void goToNextRoom()
    {
        if(currentRoom < roomCount-1)
        {
            currentRoom++;
        }
        FirstPersonController.Instance.transform.position = transform.GetChild(currentRoom).GetChild(0).GetChild(0).position + Vector3.up * 3;
        PlayerDeath.Instance.dead = false;
        FirstPersonController.Instance.gameObject.GetComponent<CharacterController>().enabled = true;
        FirstPersonController.Instance.allowJump = true;
        FirstPersonController.Instance.allowLook = true;
        FirstPersonController.Instance.allowMove = true;

        foreach(AnswerManager wall in DungeonGenerator.Instance.transform.GetChild(DungeonGenerator.Instance.currentRoom-1).
        GetChild(1).GetComponentInChildren<QuestionsManager>().GetComponentsInChildren<AnswerManager>())
        {
            wall.transform.GetChild(0).gameObject.SetActive(true);
            wall.GetComponent<Collider>().isTrigger = false;
        }
    }
}
