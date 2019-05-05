using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class pl_move : MonoBehaviour
{
    public int playerNumber;
    public float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();

        float moveHorizontal = Input.GetAxis ("Horizontal" + playerNumber);
        float moveVertical = Input.GetAxis ("Vertical" + playerNumber);

        Vector3 movement = new Vector3 (moveHorizontal, moveVertical, 0.0f);

        rb.AddForce (movement * speed);
    }
}
