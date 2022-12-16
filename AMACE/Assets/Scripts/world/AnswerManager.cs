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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowAnswer(Sprite sprite)
    {
        meshRenderer.material.mainTexture = sprite.texture;
    }
}
