using UnityEngine;
using System.Collections;


public class Enemy_AI : MonoBehaviour
{

    Transform tr_Player;
    float f_RotSpeed = 3.0f;
    float f_MoveSpeed = 3.0f;
    float maxDistance = 1.0f;
	float distanceToChar = 3;
    float currentDistance;

    // Use this for initialization
    void Start()
    {

        tr_Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        currentDistance = Vector3.Distance(tr_Player.position, this.transform.position);
		if(currentDistance > maxDistance && currentDistance < 20 && currentDistance > distanceToChar)
        {
        // Look at player
        transform.rotation = Quaternion.Slerp(transform.rotation
                             , Quaternion.LookRotation(tr_Player.position - transform.position)
                             , f_RotSpeed * Time.deltaTime);

        // Move to Player
        transform.position += transform.forward * f_MoveSpeed * Time.deltaTime;
        }
        }
	//by Victor. needs method to detect and NOT run into walls, hazards and potential allies.
	//only the player is supposed to move through some walls.
}
