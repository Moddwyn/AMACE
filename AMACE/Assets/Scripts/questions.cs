using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
[CreateAssetMenu]
public class questions : ScriptableObject
{
    public questionData[] _questions;
}
[Serializable]
public class questionData
{
    public Sprite questions;
    public int correctAnswer;
    public Sprite[] answers;
}