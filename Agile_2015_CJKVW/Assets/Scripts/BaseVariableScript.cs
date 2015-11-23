using UnityEngine;
using System.Collections;

public class BaseVariableScript : MonoBehaviour {

	[Tooltip("maximum health stat for the object/player.")]
	public float healthStat = 100f;

	[Tooltip("current health stat for the object/player.")]
	float health;

    [Tooltip("Attack speed stat for the object/player.")]
    public float atkSpeed = 1;

    [Tooltip("Attack damage stat for the object/player.")]
    public float atkDmg = 1;

    // Use this for initialization
    void Start () {
		ResetHealth ();
	}
	
	// Update is called once per frame
	void Update () {
	    if(health <= 0)
        {
            Debug.Log("defeated");
        }
	}

	public void ModHealth(float mod)
	{
		health += mod;
        Debug.Log("Current Health of Hit Creature: " + health);

    }

    public void ResetHealth()
	{
		health = healthStat;
	}

	public void ModAtkSpeed(float mod)
	{
		atkSpeed = mod;
	}
}
