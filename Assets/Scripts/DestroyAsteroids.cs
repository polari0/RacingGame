using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAsteroids : MonoBehaviour
{
	// OnTriggerEnter is called when the Collider other enters the trigger.
	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "asteroid"){
			Destroy(other.gameObject);
			Debug.Log("Collision");
		}
	}
}
