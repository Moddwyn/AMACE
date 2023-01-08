using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuestionsManager : MonoBehaviour
{
    public questions _questions;
    public MeshRenderer meshRenderer;
    public List<AnswerManager> answerManagers = new List<AnswerManager>();
    public int randExit;
    public UnityEvent onCorrect;
    public UnityEvent onWrong;

    private void Start()
    {
        if(meshRenderer != null)
            meshRenderer.enabled = false;
    }

    public void ShowQuestion()
    {
        if(QuestionsList.Instance.questionList.Count > 0)
        {
            meshRenderer.enabled = true;
            _questions = QuestionsList.Instance.GetRandomQuestion();
            meshRenderer.material.mainTexture = _questions._questions.texture;
            
            answerManagers[randExit].ShowAnswer(_questions.correctAnswer);
            answerManagers[randExit].correctAnswer = true;
            answerManagers.RemoveAt(randExit);
            for(int i = 0; i < 4; i++)
            {
                int randOther = Random.Range(0, answerManagers.Count);
                answerManagers[randOther].ShowAnswer(_questions.otherAnswers[i]);
                answerManagers.RemoveAt(randOther);
            }
        }
    }


}

