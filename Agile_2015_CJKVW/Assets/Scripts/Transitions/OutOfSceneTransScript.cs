using UnityEngine;
using System.Collections;

public class OutOfSceneTransScript : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			//move to next scene
			Application.LoadLevel ("EndScene");
		}
	}
}
