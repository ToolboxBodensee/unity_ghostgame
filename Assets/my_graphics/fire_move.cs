using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire_move : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(collider.tag);
        
        if (collider.tag == "wallofdeath")
        {
            Destroy(gameObject, 2.0f);
        }
        
        if (collider.tag == "Player")
        {
            collider.gameObject.GetComponent<pl_damage>().ApplyDamage(1.0f);
        }
    }
}
