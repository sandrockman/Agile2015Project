using UnityEngine;
using System.Collections;

public class AttackScript : MonoBehaviour {

	[Tooltip("Amount of damage for a light/base attack")]
	float baseAttackDmg;

	Quaternion startPos;
	Quaternion endPos;
	public GameObject weapon;
	public GameObject weaponArc;
    public GameObject weaponArcCube;

    public bool isAttacking = false;
    bool newAtk = true;
    public float attackSpeed;
    float startMoveTime;

    /*
	[Tooltip("Amount of damage for a medium attack")]
	float mediumAttackDmg;
	[Tooltip("Amount of damage for a heavy attack")]
	float heavyAttackDmg;
	*/

    // Use this for initialization
    void Start()
    {
        startPos = weapon.transform.rotation;
        endPos = weaponArc.transform.rotation;
        weapon.SetActive(false);
        attackSpeed = GetComponent<BaseVariableScript>().atkSpeed;
    }
	
	// Update is called once per frame
	void Update () {
	    if(isAttacking)
        {
            AttackSwing();
        }
        /*
        if(!isAttacking)
        {
            weapon.SetActive(false);
            weapon.transform.rotation = startPos;
        }
        //*/
	}

	void AttackSwing()
	{
        if(weapon.transform.rotation == startPos)
        {
            weapon.SetActive(true);
            if(newAtk)
            {
                startMoveTime = Time.time;
                newAtk = false;
            }
            //weapon.transform.rotation = Quaternion.RotateTowards(weapon.transform.rotation, endPos, Time.deltaTime * attackSpeed);

        }
        float rotateStep = Mathf.Min(1, ((Time.time - startMoveTime) * attackSpeed));
        //float fracJourney =
        //weapon.transform.rotation = Quaternion.Lerp(startPos, weaponArcCube.transform.rotation, rotateStep);
        weapon.transform.rotation = Quaternion.Slerp(weapon.transform.rotation, weaponArcCube.transform.rotation, rotateStep);
        //Debug.Log("rotation: " + weapon.transform.rotation);
        if (weapon.transform.rotation == endPos)
        {
            weapon.SetActive(false);
            weapon.transform.rotation = startPos;
            isAttacking = false;
            newAtk = true;
        }
    }

    public void CallAttack()
    {
        isAttacking = true;
        startPos = weapon.transform.rotation;
        endPos = weaponArc.transform.rotation;
    }
}
