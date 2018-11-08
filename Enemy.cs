using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private Rigidbody2D rb;
    public float speed = 5;
    private Game_Manager gm;
    private GameObject gmObj;

    // Use this for initialization
    void Start () {

        gmObj = GameObject.FindGameObjectWithTag("GameController");
        gm = gmObj.GetComponent<Game_Manager>();
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 5.0f);
        rb.velocity = Vector2.left * speed;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Shot"))
        {
            gm.enemiesKilled++;
            gameObject.SetActive(false);
            Destroy(gameObject, 0.1f);
        }
    }
}
