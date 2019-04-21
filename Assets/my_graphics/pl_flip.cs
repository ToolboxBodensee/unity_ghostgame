using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pl_flip : MonoBehaviour
{
    private GameObject pl1;
    private GameObject pl2;
        

    // Start is called before the first frame update
    void Start()
    {
        pl1 = GameObject.Find("player1");
        pl2 = GameObject.Find("player2");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pl1.transform.position.x > pl2.transform.position.x)
        {
            pl1.transform.localScale = new Vector3(-1f, 1, 1);
            pl2.transform.localScale = new Vector3(1f, 1, 1);
        }
        else
        {
            pl1.transform.localScale = new Vector3(1f, 1, 1);
            pl2.transform.localScale = new Vector3(-1f, 1, 1);
        }
    }
}
