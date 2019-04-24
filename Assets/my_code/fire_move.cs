using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire_move : MonoBehaviour
{
    public GameObject shooting_player;
    public float damage;
    public float shooter_heal;

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
            collider.gameObject.GetComponent<pl_damage>().ApplyDamage(damage);
            shooting_player.GetComponent<pl_damage>().ApplyDamage(shooter_heal*-1);
        }

        if (collider.tag == "balloon")
        {
            collider.gameObject.GetComponent<balloon_move>().Pop();
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x*-1,1,1);
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = Vector3.Reflect(rb.velocity, Vector3.left);
        }
    }
}
