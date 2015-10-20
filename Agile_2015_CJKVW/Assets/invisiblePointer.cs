using UnityEngine;
using System.Collections;

public class invisiblePointer : MonoBehaviour {
	Renderer parentRend;
	Renderer currentRend;
	// Use this for initialization
	void Start () {
		//parentRend = parent.GetComponent<Renderer> ();
		currentRend = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!parentRend.isVisible && currentRend.isVisible)
			currentRend.enabled = false;
		if (parentRend.isVisible && !currentRend.isVisible)
			currentRend.enabled = true;

	}
}
