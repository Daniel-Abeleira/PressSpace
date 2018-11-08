using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public Rigidbody2D rb;
    public float speed = 6;

    // Use this for initialization
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 5.0f);
        rb.velocity = Vector2.right * speed;

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);
        Destroy(gameObject, 0.5f);
    }
}
