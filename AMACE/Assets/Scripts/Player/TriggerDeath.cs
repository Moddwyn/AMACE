using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDeath : MonoBehaviour
{
    public bool answerDeath;
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(!answerDeath)
            {
                if (DungeonGenerator.Instance.transform.GetChild(DungeonGenerator.Instance.currentRoom).GetChild(1).
                    GetComponentInChildren<CountDown>() != null)
                {
                    DungeonGenerator.Instance.transform.GetChild(DungeonGenerator.Instance.currentRoom).GetChild(1).
                    GetComponentInChildren<CountDown>().StopCountdown();
                    PlayerDeath.Instance.Die(false);
                }
            } else
            {
                if (DungeonGenerator.Instance.transform.GetChild(DungeonGenerator.Instance.currentRoom-1).GetChild(1).
                    GetComponentInChildren<CountDown>() != null)
                {
                    DungeonGenerator.Instance.transform.GetChild(DungeonGenerator.Instance.currentRoom-1).GetChild(1).
                    GetComponentInChildren<CountDown>().StopCountdown();
                    PlayerDeath.Instance.Die(true);
                }
            }
        }
    }
}
