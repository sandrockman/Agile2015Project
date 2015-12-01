using UnityEngine;
using System.Collections;

public class delayDestroy : MonoBehaviour {


	public float waitForIt= 2.0f;

	// Use this for initialization
	void Start () {
	

		Destroy (this.gameObject, waitForIt);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
