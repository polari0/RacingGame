using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	
	private Inputs playerInputs;
	public float gameSpeed;
	[SerializeField, Range(0, 10)]
	public int gameSpeedMultiplier;
	private Vector2 speed;
	[SerializeField]
	private CharacterController characterController;
	[SerializeField]
	private GameObject DeathScreenOverlay;
	[SerializeField]
	private GameObject VicoryScreenOverLay;
	public bool hasGameEnded;
	private void Awake()
	{
		playerInputs = new Inputs();
	}
	
	// This function is called when the object becomes enabled and active.
	protected void OnEnable()
	{
		playerInputs.Enable();
	}
	// This function is called when the behaviour becomes disabled () or inactive.
	protected void OnDisable()
	{
		playerInputs.Disable();
	}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
	    Vector2 movementInput = playerInputs.PlayerMovement.		Move.ReadValue<Vector2>();
	    Vector2 move = new Vector2(movementInput.x, 0f);
	    speed = new Vector2(0f, movementInput.y);
	    gameSpeed = Mathf.Clamp(speed.y, 0f, 1f);
	    characterController.Move(move * Time.deltaTime * 			gameSpeed * gameSpeedMultiplier);
	    //Debug.Log(gameSpeed + " this is game speed");
    }
    
	// OnTriggerEnter is called when the Collider other enters the trigger.
	protected void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "asteroid"){
			DeathScreenOverlay.SetActive(true);
			hasGameEnded = true;
		}
		else if (other.gameObject.tag == "Goal"){
			hasGameEnded = true;
			VicoryScreenOverLay.SetActive(true);
		}
	}
}
