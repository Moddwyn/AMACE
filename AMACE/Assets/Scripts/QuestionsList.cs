using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionsList : MonoBehaviour
{
    public List<questions> questionList = new List<questions>();

    public static QuestionsList Instance;

    void Awake()
    {
        Instance = this;
    }

    public questions GetRandomQuestion()
    {
        if(questionList.Count > 0)
        {
            int rand = Random.Range(0, questionList.Count);
            questions myQuestion = questionList[rand];
            questionList.RemoveAt(rand);

            return myQuestion;
        }

        Debug.LogWarning("No more questions to retrieve.");
        return new questions();
        
    }
}
