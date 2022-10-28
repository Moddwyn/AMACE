using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionsManager : MonoBehaviour
{
    public TextAsset questionsJson;

    [System.Serializable]
    public class QuestionsList
    {
        public QuestionData[] questions;
    }

    [System.Serializable]
    public class QuestionData 
    {
        public string question;
        public AnswersData[] answers;
    }

    [System.Serializable]
    public class AnswersData
    {
        public string choice;
        public bool correct;
    }

    public QuestionsList questions = new QuestionsList();

    void Start()
    {
        questions = JsonUtility.FromJson<QuestionsList>(questionsJson.text);
    }

}
