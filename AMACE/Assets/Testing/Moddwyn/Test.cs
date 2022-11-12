using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
	public bool collider1;
	public bool enter;
	
	public float rotateAmount;
	public float rotateSpeed;
	
	public Transform door1;
	public Transform door2;
	
	void Update()
	{
		if(collider1)
		{
			if(enter)
			{
				door1.rotation = Quaternion.Lerp(door1.rotation, Quaternion.Euler(0,rotateAmount,0), Time.deltaTime * rotateSpeed);
				door2.rotation = Quaternion.Lerp(door2.rotation, Quaternion.Euler(0,180-rotateAmount,0), Time.deltaTime * rotateSpeed);
			}
		} else
		{
			if(enter)
			{
				door1.rotation = Quaternion.Lerp(door1.rotation, Quaternion.Euler(0,180-rotateAmount,0), Time.deltaTime * rotateSpeed);
				door2.rotation = Quaternion.Lerp(door2.rotation, Quaternion.Euler(0,rotateAmount,0), Time.deltaTime * rotateSpeed);	
			}
		}

	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
			enter = true;	
	}
	
	void OnTriggerExit(Collider other)
	{
		if(other.tag == "Player")
			enter = false;
	}
}
