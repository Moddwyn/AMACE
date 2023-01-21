using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CountDown))]
public class FireRoom : MonoBehaviour
{
    public ParticleSystem[] fires;
    CountDown countDown;

    bool fireDeath;

    void Start()
    {
        countDown = GetComponent<CountDown>();
    }

    public void PlayFire()
    {
        foreach (var item in fires)
        {
            item.Play();
            FirstPersonController.Instance.fireVolume.enabled = true;
        }
    }

    void Update()
    {
        if(countDown.countdownFinish && !fireDeath)
        {
            fireDeath = true;
            FirstPersonController.Instance.fireVolume.enabled = false;
            PlayerDeath.Instance.Die(false);
        }
    }
}
