﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float jumpForce = 10;
    public Rigidbody2D rb;
    public GameObject bulletPrefab;
    public Transform shotPoint;
    public int lifes = 1;

	// Use this for initialization
	void Start () {
        lifes = 1;
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;
            Instantiate(bulletPrefab, shotPoint.transform.position, Quaternion.identity);
        }
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == ("Enemy") || collision.collider.tag == ("Obstacle"))
        {
            lifes--;
        }
    }
}
