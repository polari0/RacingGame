﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
	[SerializeField]
	GameObject DeathOverlay, VictoryOverLay;
	public void ReloadScene(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
	
}
