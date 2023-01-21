using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering.PostProcessing;

public class WaterRise : MonoBehaviour
{
    public Vector3 waterLevel;
    public bool waterRiseStart;
    public bool waterRiseFinish;
    public Transform waterRise;
    public float riseSpeed;
    public bool done;
    public bool answered;
    bool activeRN;

    // Start is called before the first frame update
    void Start()
    {
        EnableWater(false);
    }
    public void EnableWater(bool active)
    {
        waterRise.gameObject.SetActive(active);
    }

    // Update is called once per frame
    void Update()
    {
        if(waterRiseStart && !waterRiseFinish && !SoundManager.Instance.source.isPlaying)
        {
            SoundManager.Instance.source.PlayOneShot(SoundManager.Instance.waterSound);
        }

        if(activeRN)
        {
            FirstPersonController.Instance.waterVolume.enabled =
            waterRise.transform.position.y > FirstPersonController.Instance.GetCamera().position.y && waterRise.gameObject.activeSelf && !waterRiseFinish ;
        }
        if(waterRiseStart && !waterRiseFinish)
        {
            waterRise.localPosition = Vector3.MoveTowards(waterRise.localPosition, waterLevel, Time.deltaTime * riseSpeed);
        }
        if(waterRise.localPosition.y >= waterLevel.y && !done)
        {
            waterRiseFinish = true;
        }

        if(waterRiseFinish && !answered)
        {
            done = true;
            waterRiseFinish = false;
            SoundManager.Instance.source.Stop();
            PlayerDeath.Instance.Die(false);
        }
    }

    public void RiseUp()
    {
        waterRiseStart = true;
        activeRN = true;
    }
}
