using UnityEngine;
using System.Collections;

public class ParticleBehaviour : MonoBehaviour {

	ParticleSystem self;
	// Use this for initialization
	void Start () {
		self =  GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!self.IsAlive())
			Destroy (gameObject);
	}
}
