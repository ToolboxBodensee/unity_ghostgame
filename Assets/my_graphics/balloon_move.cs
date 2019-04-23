using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class balloon_move : MonoBehaviour
{
    public float speed = 40.0f;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        foreach(GameObject wallofdeath in GameObject.FindGameObjectsWithTag("wallofdeath"))
            Physics2D.IgnoreCollision(wallofdeath.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        Respawn();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Pop()
    {
        animator.SetTrigger("Pop");
        Invoke("Respawn", 0.25f);
    }

    void OnBecameInvisible() {
        Invoke("Respawn", 0.25f);
    }

    public void Respawn()
    {
        System.Random rnd = new System.Random();
        transform.position = new Vector3((float)rnd.Next(-6, 6), -8.0f, -0.5f);

        speed = (float)rnd.Next(30, 60);

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.zero;
        Vector3 movement = new Vector3(0.0f, 1.0f, 0.0f);
        rb.AddForce(movement * speed);

        animator.ResetTrigger("Pop");
    }
}
