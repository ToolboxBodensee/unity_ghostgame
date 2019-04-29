using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
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
        if (collider.tag == "Player")
        {
            collider.gameObject.GetComponent<pl_state>().SetShieldEnabled(true);

            GetComponent<AudioSource>().Play();
            transform.position = new Vector3(-99, -99, -99);
            Destroy(gameObject, 0.5f);
        }
    }
}
