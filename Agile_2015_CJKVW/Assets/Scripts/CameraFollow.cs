using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public float distanceFromPlayer;
	public float cameraHeight = 5;

	public Transform cameraTarget;

	Vector3 startLoc;
	Vector3 endLoc;
	public float smooth = 5.0f;


	// Use this for initialization
	void Start () {
		//transform.LookAt (cameraTarget);
		transform.position = FindPos ();
		transform.LookAt (cameraTarget);
	}
	
	// Update is called once per frame
	void Update () {
		//UpdateLook ();
		Follow ();	

	}

	void Follow(){
		startLoc = transform.position;
		endLoc = FindPos ();
		transform.position = Vector3.Lerp (startLoc, endLoc, Time.deltaTime * smooth);
	}

	/*
	void UpdateLook()
	{
		Vector3 relativePos = cameraTarget.position - transform.position;
		Quaternion rotation = Quaternion.LookRotation (relativePos);
		rotation.y = 0;
		rotation.z = 0;
		transform.rotation = Quaternion.Lerp (transform.rotation,
		                                      rotation,
		                                      Time.deltaTime);
	}*/

	Vector3 FindPos()
	{
		return new Vector3(
			cameraTarget.position.x,
			(cameraTarget.position.y + cameraHeight),
			(cameraTarget.position.z - distanceFromPlayer));
	}
}
