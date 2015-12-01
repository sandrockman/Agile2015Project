using UnityEngine;
using System.Collections;

public class HitScript : MonoBehaviour {

	public BaseVariableScript variableScript;

	// Use this for initialization
	void Start () {
        variableScript = GetComponent<BaseVariableScript>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Weapon")
        {
			float dmg = other.GetComponentInParent<BaseVariableScript>().atkDmg;
            TakeDamage(dmg);
            Debug.Log("hit.");
        }
    }

    void TakeDamage(float dmg)
	{
        variableScript.ModHealth(-dmg);
		if (variableScript.GetHealth () <= 0) {
			Destroy(this.gameObject);
		}
	}
}
