using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class fire_trigger : NetworkBehaviour
{
    [SyncVar]
    public GameObject shooting_player;
    //private Vector3 direction;

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
        if (isServer)
        {
            if (collider.tag == "wallofdeath")
            {
                StartCoroutine(DelayedDestroy());
            }
            else if (collider.tag == "Player")
            {
                HitPlayer();
            }
            else if (collider.tag == "balloon")
            {
                HitBalloon();
            }
        }
    }

    [Server]
    IEnumerator DelayedDestroy()
    {
        yield return new WaitForSeconds(0.25f);
        NetworkServer.Destroy(gameObject);
    }

    [Server]
    private void HitPlayer()
    {
        GetComponent<Collider2D>().gameObject.GetComponent<pl_damage>().ApplyDamage(damage);
        shooting_player.GetComponent<pl_damage>().ApplyDamage(shooter_heal*-1);
    }

    [Server]
    private void HitBalloon()
    {
        Debug.Log("hit balloon");
        GetComponent<Collider2D>().gameObject.transform.parent.GetComponent<balloon_move>().CmdPop();
        gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x*-1,1,1);
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.Reflect(rb.velocity, Vector3.left);
        Debug.Log("hit balloon end");
    }
}
