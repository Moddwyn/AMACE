using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class archdoor : MonoBehaviour
{
    public bool collider1;
    public bool enter;
    public Transform door1;
    public Transform door2;
    public float rotationAmount;
    public float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enter)
        {
            if (collider1)
            {
                door1.localRotation = Quaternion.Lerp(door1.localRotation, Quaternion.Euler(0, rotationAmount, 0), Time.deltaTime * rotationSpeed);
                door2.localRotation = Quaternion.Lerp(door2.localRotation, Quaternion.Euler(0, 180 - rotationAmount, 0), Time.deltaTime * rotationSpeed);

            }
            else
            {
                door1.localRotation = Quaternion.Lerp(door1.localRotation, Quaternion.Euler(0, 180 - rotationAmount, 0), Time.deltaTime * rotationSpeed);
                door2.localRotation = Quaternion.Lerp(door2.localRotation, Quaternion.Euler(0, rotationAmount, 0), Time.deltaTime * rotationSpeed);
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            enter = true;
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            enter = false;
    }
}
