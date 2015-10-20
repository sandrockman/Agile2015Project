using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {

	public float pMoveDist = 2.5f;
	public float pSpeed = 6f;
	public float pDistCheck = 0.2f;

	public ParticleSystem teleportEffect;

	
	float horzMove = 0;
	float vertMove = 0;
	float startMoveTime;
	float moveLength;
	bool currentlyMoving;

	Vector3 startLocation;
	Vector3 targetLocation;


	// Use this for initialization
	void Start () {
		currentlyMoving = false;
		
		targetLocation = startLocation = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		ReadMoveCommands ();
		if (currentlyMoving) 
		{
			TeleLerp ();
			if(transform.position == targetLocation)
			{
				currentlyMoving = false;
			}
		} 
		else // !currentlyMoving
		{
			SetTeleLerpPoint();
		}
	}

	void ReadMoveCommands()
	{
		horzMove = Input.GetAxis ("Horizontal");
		vertMove = Input.GetAxis ("Vertical");
	}

	void SetTeleLerpPoint()
	{
		if(horzMove != 0 || vertMove != 0)
		{
			//start setting new location for move/teleport
			//set start Location at current spot
			startLocation = transform.position;
			//set targetLocation from current spot
			targetLocation = transform.position;
			//set movement rate, depending on axes
			if(horzMove > pDistCheck)
				targetLocation.x += pMoveDist;
			if(horzMove < -pDistCheck)
				targetLocation.x -= pMoveDist;
			if(vertMove > pDistCheck)
				targetLocation.z += pMoveDist;
			if(vertMove < -pDistCheck)
				targetLocation.z -= pMoveDist;
			//find plane or terrain y position so move to legal vertical location
			
			//should either move a collider to or create one at this new location
			//to find if the move was legal
			
			//move target is set. 

			//set start time
			startMoveTime = Time.time;
			//set move distance
			moveLength = Vector3.Distance(transform.position, targetLocation);
			//Now signify player is moving.
			currentlyMoving = true;
		}
	}
	
	void TeleLerp()
	{
		//if character starts movement...
		//disable view of player AND 
		//start particle effect of begin teleport at point
		create
		
		//lerp toward targetLocation
		float distCovered = (Time.time - startMoveTime) * pSpeed;
		float fracJourney = distCovered / moveLength;
		transform.position = Vector3.Lerp(startLocation, targetLocation, fracJourney);
		
		//if character ends movement...
		//enable view of player AND 
		//start particle effect of end teleport at point
		
	}
}
