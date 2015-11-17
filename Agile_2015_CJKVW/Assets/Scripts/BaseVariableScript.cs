using UnityEngine;
using System.Collections;

public class BaseVariableScript : MonoBehaviour {

	[Tooltip("health stat for the object/player.")]
	float healthStat = 100f;

	float health;

	[Tooltip("health stat for the object/player.")]
	float atkSpeed = 1;

	// Use this for initialization
	void Start () {
		ResetHealth ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void ModHealth(float mod)
	{
		health += mod;
	}

	void ResetHealth()
	{
		health = healthStat;
	}

	void ModAtkSpeed(float mod)
	{
		atkSpeed = mod;
	}
}
