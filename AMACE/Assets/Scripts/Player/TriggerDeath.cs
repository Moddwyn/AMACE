using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDeath : MonoBehaviour
{
    void Start()
    {
        foreach(ParticleSystem fire in transform.parent.parent.GetComponentsInChildren<ParticleSystem>())
        {
            fire.Stop();
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            foreach(ParticleSystem fire in transform.parent.parent.GetComponentsInChildren<ParticleSystem>())
            {
                fire.Play();
            }
            if (DungeonGenerator.Instance.transform.GetChild(DungeonGenerator.Instance.currentRoom).GetChild(1).
                GetComponentInChildren<CountDown>() != null)
            {
                DungeonGenerator.Instance.transform.GetChild(DungeonGenerator.Instance.currentRoom).GetChild(1).
                GetComponentInChildren<CountDown>().StopCountdown();
            }
            SoundManager.Instance.fxSource.PlayOneShot(SoundManager.Instance.wrongAnswer);
            PlayerDeath.Instance.Die(false);
        }
    }
}
