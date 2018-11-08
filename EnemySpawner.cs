using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrefab;
    public Game_Manager gm;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        float random = Random.Range(0.0f, 250.0f);
        if(random < 1)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        }
	}
}
