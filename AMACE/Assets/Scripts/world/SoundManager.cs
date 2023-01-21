using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource source;
    public AudioClip correctAnswer;
    public AudioClip wrongAnswer;
    public AudioClip waterSound;

    public static SoundManager Instance;

    void Awake()
    {
        Instance = this;
    }
}
