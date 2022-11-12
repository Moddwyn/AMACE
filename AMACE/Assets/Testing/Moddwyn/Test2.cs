using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    
	public Transform randomObject;
    public float rotationValue;
    public float speed;
    
    void Update()
    {
        // Time.deltaTime -> over time
        randomObject.rotation = Quaternion.Lerp(randomObject.rotation, Quaternion.Euler(0,rotationValue,0), Time.deltaTime * speed);
    }
}
