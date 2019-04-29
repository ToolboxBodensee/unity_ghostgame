using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class pl_fire : NetworkBehaviour
{
    public int playerNumber = 1;
    public GameObject firepos;
    public GameObject fireshot;
    public string fireKey = "Fire";
    public float cooldownTime;

    public float firespeed;

    private float fire = 0.0f;
    private bool firePossible = true;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    [Client]
    void Update()
    {
        if (!isLocalPlayer)
        {
            // exit from update if this is not the local player
            return;
        }

        if (fire > 0.0f)
            fire -= Time.deltaTime;

        if (Input.GetButton(fireKey + playerNumber))
        {
            if (fire <= 0.0f && firePossible)
            {
                firePossible = false;
                fire = cooldownTime;

                CmdSpawnFireball();
            }
        }
        else
            firePossible = true;
    }

    [Command]
    private void CmdSpawnFireball()
    {
        RpcSpawnFireball();
        Vector3 fireposition = firepos.transform.position;

        GameObject shot = Instantiate(fireshot, fireposition, Quaternion.identity);
        shot.GetComponent<fire_trigger>().shooting_player = gameObject;

        shot.transform.localScale = transform.localScale;

        Rigidbody2D rb = shot.GetComponent<Rigidbody2D>();
        Rigidbody2D rb_player = GetComponent<Rigidbody2D>();

        Vector3 movement = new Vector3(transform.localScale.x, 0.0f, 0.0f);
        rb.velocity = new Vector3(0.0f, rb_player.velocity.y, 0.0f);
        rb.AddForce(movement * firespeed);
        NetworkServer.Spawn(shot);
    }

    [ClientRpc]
    private void RpcSpawnFireball()
    {
        GetComponent<Animator>().SetTrigger("Fire");
    }
}
