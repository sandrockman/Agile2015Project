using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {

	public float pMoveDist = 2.5f;
	public float pSpeed = 6f;
	public float pDistCheck = 0.02f;

	public ParticleSystem teleportEffect;
	Renderer render;

	[Tooltip("horizontal movement amount by axis")]
	public float horzMove = 0;
	[Tooltip("vertical movement amount by axis")]
	public float vertMove = 0;
	float startMoveTime;
	float moveLength;
	float heightToCenter;
	bool currentlyMoving;

	Vector3 startLocation;
	Vector3 targetLocation;

	//used to check if the player can phase through out-of-bounds areas
	bool canPhase = false;
	//checks if they are in the start of a move sequence for teleport effect.
	bool startMove = false;
	float whereToFace;

	// Use this for initialization
	void Start () {
		render = GetComponent<Renderer> ();
		heightToCenter = GetComponent<CapsuleCollider> ().height / 2;
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
			//find direction to face
			FindFacing();
			//find plane or terrain y position so move to legal vertical location
			
			//should either move a collider to or create one at this new location
			//to find if the move was legal
			CanPlayerPhase();
			//move target is set. 

			//set start time
			startMoveTime = Time.time;
			//set move distance
			moveLength = Vector3.Distance(transform.position, targetLocation);
			//Now signify player is moving.
			startMove = true;
			currentlyMoving = true;
		}
	}
	
	void TeleLerp()
	{
		//if character starts movement...
		//disable view of player AND 
		//start particle effect of begin teleport at point
		if (startMove) {
			startMove = false;
			ParticleSystem newBamf = (ParticleSystem) Instantiate(teleportEffect, 
			                                                      transform.position, 
			                                                      Quaternion.Euler(0,0,0));
			render.enabled = false;	
			//Quaternion newRotation = transform.rotation;
			//newRotation.y = whereToFace;
			//transform.rotation = newRotation;

			//Debug.Log ("whereToFace = " + whereToFace +
			//		   ", newRotation.y = " + newRotation.y +
			  //         "\ntransform.rotation.y = " + transform.rotation.y);
			//Vector3 targetLocation
			transform.rotation = Quaternion.LookRotation(targetLocation);
		}
		
		//lerp toward targetLocation
		float distCovered = (Time.time - startMoveTime) * pSpeed;
		float fracJourney = distCovered / moveLength;
		transform.position = Vector3.Lerp(startLocation, targetLocation, fracJourney);

		//if character ends movement...
		//enable view of player AND 
		//start particle effect of end teleport at point
		if (transform.position == targetLocation) {
			ParticleSystem newBamf = (ParticleSystem)Instantiate(teleportEffect,
			                                                     transform.position,
			                                                     Quaternion.Euler(0,0,0));
			render.enabled = true;
		}
	}

	//changes variable for a y-rotation value. 
	//This will be used for player facing and orientation.
	//@pre only used after finding new move inputs.
	void FindFacing()
	{
		if (Mathf.Abs (horzMove) < pDistCheck) {
			if (vertMove > pDistCheck)
				whereToFace = 0;//north
			else if (vertMove < -pDistCheck)
				whereToFace = 180;//south
		} else {
			Debug.Log("Set Facing anything other than straight north/south");
			if(horzMove > pDistCheck){
				if(vertMove > pDistCheck){
					whereToFace = 45;//north east
				}
				else if(vertMove < -pDistCheck){
					whereToFace = 135;//south east
				}
				else{
					whereToFace = 90;//east
				}
			} else if(horzMove > pDistCheck){
				if(vertMove > pDistCheck){
					whereToFace = 315;//north west
				}
				else if(vertMove < -pDistCheck){
					whereToFace = 225;//south west
				}
				else{
					whereToFace = 270;//west
				}
			}
		}
		Debug.Log ("Where to face angle is - " + whereToFace);
	}
	//Checks if player can phase through walls/obtacles to location
	//before character starts moving.
	void CanPlayerPhase()
	{
		float checkRadius = GetComponent<CapsuleCollider> ().radius;
		Collider[] hitColliders = Physics.OverlapSphere (targetLocation, checkRadius);
		canPhase = true;
		if(hitColliders.Length > 0)
		{
			foreach(Collider hit in hitColliders)
			{
				if(hit.tag == "OutOfBounds" || hit.tag == "Enemy")
				{
					canPhase = false;
				}
			}
		}
	}
}
