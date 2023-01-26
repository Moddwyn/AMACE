using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioSource fxSource;
    public AudioSource musicSource;
    public AudioClip correctAnswer;
    public AudioClip wrongAnswer;
    public AudioClip waterSound;
    public AudioClip fireSound;
    public Slider audioSlider;

    public static SoundManager Instance;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        audioSlider.value = 0.5f;
    }

    void Update()
    {
        fxSource.volume = audioSlider.value;
        musicSource.volume = audioSlider.value/6;
    }
}
