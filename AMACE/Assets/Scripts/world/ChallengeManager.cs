using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChallengeManager : MonoBehaviour
{
    public bool ChallengeStart;
    public UnityEvent onStart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && ChallengeStart == false)
        {
            ChallengeStart = true;
            SoundManager.Instance.roomSource.Stop();
            onStart.Invoke();
            DungeonGenerator.Instance.UpdateCurrentRoomVisibility();
        }


    }
}
