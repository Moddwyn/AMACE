using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class archdoor : MonoBehaviour
{
    public bool collider1;
    public bool enter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        enter = true;
    }

    private void OnTriggerExit(Collider other)
    {
        enter = false;
    }
}
