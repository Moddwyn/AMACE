using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionsManager : MonoBehaviour
{
    public List<questions> _questions = new List<questions>();
    public static QuestionsManager instance;
    public MeshRenderer meshRenderer;

    private void Awake()
    {
        instance = this;
    }

    public void ShowQuestion()
    {
        int randQuestion = Random.Range(0, _questions.Count);
        meshRenderer.material.mainTexture = _questions[randQuestion]._questions.texture;
    }
}

