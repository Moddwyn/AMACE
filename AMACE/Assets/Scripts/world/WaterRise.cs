using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaterRise : MonoBehaviour
{
    public Vector3 waterLevel;
    public bool waterRiseStart;
    public bool waterRiseFinish;
    public Transform waterRise;
    public float riseSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(waterRiseStart && !waterRiseFinish)
        {
            waterRise.localPosition = Vector3.MoveTowards(waterRise.localPosition, waterLevel, Time.deltaTime * riseSpeed);
        }
        if(waterRise.localPosition.y >= waterLevel.y)
        {
            waterRiseFinish = true;
        }
    }

    public void RiseUp()
    {
        waterRiseStart = true;
    }
}
