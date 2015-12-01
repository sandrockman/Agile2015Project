using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

    public GameObject[] enemies;
    public int amount;
    private Vector3 spawnPoint;
    public KeyCode keySpawnEnemy;
	
	// Update is called once per frame
	void Update () 
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        amount = enemies.Length;

        if(amount != 3)
        {
            InvokeRepeating("spawnEnemy", 5, 10f);
        }

        if(Input.GetKeyDown(keySpawnEnemy))
        {
            InvokeRepeating("spawnEnemy", 5, 10f);
        }
	}
    void spawnEnemy()
    {
        spawnPoint.x = Random.Range(-20, 20);
        spawnPoint.y = 1.5f;
        spawnPoint.z = Random.Range(-20, 20);

        Instantiate(enemies[UnityEngine.Random.Range(0, enemies.Length - 1)], spawnPoint, Quaternion.identity);
        CancelInvoke();
    }
	//by Victor. spawn function needs check to see if chosen spawn point is legal for drop.
}
