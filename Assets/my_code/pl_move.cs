using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class pl_move : MonoBehaviour
{
    public int playerNumber;
    public float speed = 2f;
    
    public Dictionary<string, string> keys1 = new Dictionary<string, string>();
    public Dictionary<string, string> keys2 = new Dictionary<string, string>();
    
    private Vector3 dir;
    private float fire;
    
    public GameObject fireshot;
    
    public float facing;

    // Start is called before the first frame update
    void Start()
    {
        keys1.Add("LEFT", "a");
        keys1.Add("RIGHT", "d");
        keys1.Add("UP", "w");
        keys1.Add("DOWN", "s");
        keys1.Add("FIRE", "q");
        
        keys2.Add("LEFT", "j");
        keys2.Add("RIGHT", "l");
        keys2.Add("UP", "i");
        keys2.Add("DOWN", "k");
        keys2.Add("FIRE", "u");
        
        dir = new Vector3(0, 0, 0);
        fire = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 pos = transform.position;
        //Dictionary<string, string> keys;
        
        Rigidbody rb = this.GetComponent<Rigidbody>();
        
        float moveHorizontal = Input.GetAxis ("Horizontal" + playerNumber);
        float moveVertical = Input.GetAxis ("Vertical" + playerNumber);
        
        //Debug.Log("hor: " + (moveHorizontal) + " / ver: " + (moveVertical));

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        rb.AddForce (movement * speed);
        /*
        if (moveHorizontal < 0)
            GetComponent<SpriteRenderer>().flipX = true;
        else if (moveHorizontal > 0)
            GetComponent<SpriteRenderer>().flipX = false;
        */
        
        /*
        // flip graphics
        GameObject pl1 = GameObject.Find("player1");
        GameObject pl2 = GameObject.Find("player2");
        
        if (pl1.transform.position.x > pl2.transform.position.x)
        {
            pl1.GetComponent<pl_move>().facing = -1.0f;
            pl2.GetComponent<pl_move>().facing = 1.0f;
        }
        else
        {
            pl1.GetComponent<pl_move>().facing = 1.0f;
            pl2.GetComponent<pl_move>().facing = -1.0f;
        }
        
        if (facing < 0)
            GetComponent<SpriteRenderer>().flipX = true;
        else
            GetComponent<SpriteRenderer>().flipX = false;
            */
    }
}

