using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDeath : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (DungeonGenerator.Instance.transform.GetChild(DungeonGenerator.Instance.currentRoom).GetChild(1).
                GetComponentInChildren<CountDown>() != null)
            {
                DungeonGenerator.Instance.transform.GetChild(DungeonGenerator.Instance.currentRoom).GetChild(1).
                GetComponentInChildren<CountDown>().StopCountdown();
                PlayerDeath.Instance.Die(false);
            }
        }
    }
}
