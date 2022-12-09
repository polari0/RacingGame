using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
	private float asteroidSpeed;
	[SerializeField, Range(0,10)]
	private int asteroidSpeedMutliplier;
	[SerializeField]
	GameObject asteroid;
	[SerializeField]
	PlayerController player_ControllerScrip;
	Vector3 target;
	// Awake is called when the script instance is being loaded.
	protected void Awake()
	{
		GetTargetPosition();
		player_ControllerScrip = FindObjectOfType<PlayerController>();
	}
	
	// Update is called every frame, if the MonoBehaviour is enabled.
	protected void Update()
	{
		asteroidSpeed = player_ControllerScrip.gameSpeed * asteroidSpeedMutliplier + 1f;
		transform.position = Vector3.MoveTowards(transform.position, target, asteroidSpeed * Time.deltaTime);
		if(player_ControllerScrip.hasGameEnded){
			Destroy(this.gameObject);
		}
	}
	
	private void GetTargetPosition()
	{
		float screenX;
		screenX = Random.Range(-3f, 3f);
		
		target = new Vector3(screenX, 0f, -10f);
	}
}
