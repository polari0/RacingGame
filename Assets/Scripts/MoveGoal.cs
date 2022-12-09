using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGoal : MonoBehaviour
{
	private float goalSpeed;
	[SerializeField, Range(0, 10)]
	private int goalSpeedMultiplier;
	[SerializeField]
	GameObject goal;
	private PlayerController player_controllrScirpt;
	
	// Awake is called when the script instance is being loaded.
	protected void Awake()
	{
		player_controllrScirpt = FindObjectOfType<PlayerController>();
	}
	// Update is called every frame, if the MonoBehaviour is enabled.
	protected void Update()
	{
		goalSpeed = player_controllrScirpt.gameSpeed * goalSpeedMultiplier;
		if(player_controllrScirpt.gameSpeed != 0){
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(0f, 0f, -3f), goalSpeed * Time.deltaTime);
		}
	}
}
