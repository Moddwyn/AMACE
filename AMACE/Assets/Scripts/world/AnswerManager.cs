using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerManager : MonoBehaviour
{
    public bool correctAnswer;
    public MeshRenderer meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowAnswer(Sprite sprite)
    {
        meshRenderer.enabled = true;
        meshRenderer.material.mainTexture = sprite.texture;
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
        }


    }
}
