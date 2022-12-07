using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObstacleSpawner : MonoBehaviour
{
	public int numberToSpawn;

	public List<GameObject> spawnpool;
	public List<GameObject> spawnLocation;
	public bool gameOver = false;
	[SerializeField]
	//These lists store what to spawn and position to spawn. 
	public GameObject spawnArea;
	
	private float spawnSpeedMultiplier;
	private float spawnTimer;
	[SerializeField]
	PlayerController player_PlayerController_Script;
	
	// Awake is called when the script instance is being loaded.
	protected void Awake()
	{
		StartCoroutine(ObstacleSpawnTimer());
		Debug.Log("spawnTimer Running");
	}
	
	public void SpawnObjects()
	{
		int randomItem = 0;
		GameObject toSpawn;
		MeshCollider c = spawnArea.GetComponent<MeshCollider>();
		float screenX, screenY;
		Vector2 pos;
		randomItem = Random.Range(0, spawnpool.Count);
		toSpawn = spawnpool[randomItem];
		screenX = Random.Range(c.bounds.min.x, c.bounds.max.x);
		screenY = Random.Range(c.bounds.min.y, c.bounds.min.y);
		pos = new Vector2(screenX, screenY);
		Instantiate(toSpawn, pos, toSpawn.transform.rotation);
	}
	
	private void SpawnFromLocation()
	{
		int objectIndex;
		GameObject objectToSpawn;
		int spawnpos = Random.Range(0, spawnLocation.Count);
		objectIndex = Random.Range(0, spawnpool.Count);
		objectToSpawn = spawnpool[objectIndex];
		Instantiate(objectToSpawn, spawnLocation[spawnpos].transform.position, transform.rotation);
	}
	
	// Update is called every frame, if the MonoBehaviour is enabled.
	protected void Update()
	{
		spawnSpeedMultiplier = player_PlayerController_Script.gameSpeedMultiplier/2;
		spawnTimer = (1.5f/player_PlayerController_Script.gameSpeed * spawnSpeedMultiplier) + 0.001f;
		//Debug.Log(spawnTimer + " this is spawn timer");
	}
	
	IEnumerator ObstacleSpawnTimer()
	{
		while(!gameOver){
			SpawnFromLocation();
			yield return new WaitForSeconds(2f);
			//if(spawnTimer != 0){
				
			//	Debug.Log("We are here");
			//}
			//else if (spawnTimer == 0){
			//	yield return new WaitForSeconds(0.1f);
			//	Debug.Log("hey");
			//}
			//if(gameOver){
			//	StopCoroutine(ObstacleSpawnTimer());
			//}
		}
	}
}

