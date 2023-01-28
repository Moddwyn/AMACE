using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnswerManager : MonoBehaviour
{
    public bool correctAnswer;
    public TMP_Text text;

    DungeonGenerator dungeonGenerator;
    // Start is called before the first frame update
    void Start()
    {
        dungeonGenerator = DungeonGenerator.Instance;
        dungeonGenerator.UpdateCurrentRoomVisibility();
        text.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowAnswer(string answerString)
    {
        text.text = answerString;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FirstPersonController.Instance.fireVolume.enabled = false;
            FirstPersonController.Instance.waterVolume.enabled = false;
            if (correctAnswer)
            {
                transform.parent.GetComponent<QuestionsManager>().onCorrect?.Invoke();
                StatsCounter.Instance.totalCorrect++;
                SoundManager.Instance.fxSource.PlayOneShot(SoundManager.Instance.correctAnswer);
                
            }
            else
            {
                transform.parent.GetComponent<QuestionsManager>().onWrong?.Invoke();
            }
            transform.GetChild(0).gameObject.SetActive(true);
            
            if (transform.parent.parent.GetComponentInChildren<CountDown>() != null)
            {
                transform.parent.parent.GetComponentInChildren<CountDown>().StopCountdown();
            }
            if (transform.parent.parent.GetComponentInChildren<WaterRise>() != null)
            {
                transform.parent.parent.GetComponentInChildren<WaterRise>().answered = true;
                transform.parent.parent.GetComponentInChildren<WaterRise>().EnableWater(false);
            }

            if(dungeonGenerator.currentRoom < dungeonGenerator.roomCount-1 && correctAnswer)
            {
                dungeonGenerator.currentRoom++;
            }
            dungeonGenerator.UpdateCurrentRoomVisibility();

            if(correctAnswer)
                StatsCounter.Instance.totalRooms++;

            SoundManager.Instance.roomSource.Stop();
        }


    }

    IEnumerator StopSound()
    {
        yield return new WaitForSeconds(1);
        SoundManager.Instance.fxSource.Stop();

    }
}
