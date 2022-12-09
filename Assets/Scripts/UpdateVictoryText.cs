using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateVictoryText : MonoBehaviour
{
	[SerializeField]
	TextMeshProUGUI victoryScreenTimerText;
	private Timer timer_Script;
	
	// Awake is called when the script instance is being loaded.
	protected void Awake()
	{
		timer_Script = FindObjectOfType<Timer>();
	}
	// This function is called when the object becomes enabled and active.
	protected void OnEnable()
	{
		victoryScreenTimerText.text = "You reached the goal in " + timer_Script.currentTime.ToString(timer_Script.timerFormats[timer_Script.formats]) + " Seconds";
	}
	
}
