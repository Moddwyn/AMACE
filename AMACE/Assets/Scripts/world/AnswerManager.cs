using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnswerManager : MonoBehaviour
{
    public bool correctAnswer;
    public TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
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
            if (correctAnswer)
                transform.parent.GetComponent<QuestionsManager>().onCorrect?.Invoke();
            else
                transform.parent.GetComponent<QuestionsManager>().onWrong?.Invoke();
            transform.GetChild(0).gameObject.SetActive(true);
            
            if (transform.parent.parent.GetComponentInChildren<CountDown>() != null)
            {
                transform.parent.parent.GetComponentInChildren<CountDown>().StopCountdown();
            }

            if(DungeonGenerator.Instance.currentRoom < DungeonGenerator.Instance.roomCount-1)
            {
                DungeonGenerator.Instance.currentRoom++;
            }
        }


    }
}
