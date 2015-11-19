using UnityEngine;
using System.Collections;

public class AttackScript : MonoBehaviour {

	[Tooltip("Amount of damage for a light/base attack")]
	float baseAttackDmg;

	Quaternion startPos;
	Quaternion endPos;
	public GameObject weapon;
	public GameObject weaponArc;

	/*
	[Tooltip("Amount of damage for a medium attack")]
	float mediumAttackDmg;
	[Tooltip("Amount of damage for a heavy attack")]
	float heavyAttackDmg;
	*/

	// Use this for initialization
	void Start () {
		startPos = weapon.transform.rotation;
		endPos = weaponArc.transform.rotation;
		//weapon.activeSelf = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void AttackSwing()
	{

	}


}
