using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Networking;

public class pl_move : NetworkBehaviour
{
    public int playerNumber = 1;
    public float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
        {
            // exit from update if this is not the local player
            return;
        }

        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();

        float moveHorizontal = Input.GetAxis ("Horizontal" + playerNumber);
        float moveVertical = Input.GetAxis ("Vertical" + playerNumber);

        //Debug.Log("hor: " + (moveHorizontal) + " / ver: " + (moveVertical));

        Vector3 movement = new Vector3 (moveHorizontal, moveVertical, 0.0f);

        rb.AddForce (movement * speed);
    }
}
