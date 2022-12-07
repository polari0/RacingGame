using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerometer : MonoBehaviour
{
	public bool isFlat;
	
	
	
	public Rigidbody rigid;
	
	private void start ()
	{
		//rigid = GetComponent<Rigidbody>();
	}


	private void Update()
	{
		Vector3 tilt = Input.acceleration;
		
		if(isFlat){
			tilt = Quaternion.Euler(90, 0, 0) * tilt;
		}
		
		rigid.AddForce(tilt);
	}
}
