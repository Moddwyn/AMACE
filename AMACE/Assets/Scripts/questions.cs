using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
[CreateAssetMenu]
public class questions : ScriptableObject
{
    public Sprite _questions;
    public int correctAnswer;
    public Sprite[] answers;
}
