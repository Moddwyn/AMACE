using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject[] rooms;
    public float delayTime;

    int currentRoom;
    
    void Start()
    {
        StartCoroutine(SwitchRooms());
    }

    void Update()
    {
        foreach (var room in rooms)
        {
            room.SetActive(Array.IndexOf(rooms, room) == currentRoom);
        }
    }

    IEnumerator SwitchRooms()
    {
        if(currentRoom < rooms.Length-1)
        {
            currentRoom++;
        } else currentRoom = 0;
        yield return new WaitForSeconds(delayTime);
        StartCoroutine(SwitchRooms());
    }

}
