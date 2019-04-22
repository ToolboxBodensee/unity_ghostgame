using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pl_fire : MonoBehaviour
{
    public int playerNumber;
    public GameObject firepos;
    public GameObject fireshot;
    public float firespeed;
    public string fireKey = "Fire";
    private Animator animator;
    //private int the_z_index;

    public float cooldownTime;

    private float fire = 0.0f;
    private bool firePossible = true;

    // Start is called before the first frame update
    void Start()
    {
        pl_move script = this.GetComponent<pl_move>();
        playerNumber = script.playerNumber;
        animator = GetComponent<Animator>();
        //the_z_index = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (fire > 0.0f)
            fire -= Time.deltaTime;

        if (Input.GetButton(fireKey + playerNumber))
        {
            Debug.Log(fireKey + playerNumber + "   " + Input.GetButton(fireKey + playerNumber));

            if (fire <= 0.0f && firePossible)
            {
                firePossible = false;
                fire = cooldownTime;

                animator.SetTrigger(fireKey);

                Vector3 fireposition = firepos.transform.position;


                GameObject shot = Instantiate(fireshot, fireposition, Quaternion.identity);
                shot.GetComponent<fire_move>().shooting_player = gameObject;

                shot.transform.localScale = transform.localScale;

                Rigidbody2D rb = shot.GetComponent<Rigidbody2D>();
                Rigidbody2D rb_player = GetComponent<Rigidbody2D>();

                Vector3 movement = new Vector3(transform.localScale.x, 0.0f, 0.0f);
                rb.velocity = new Vector3(0.0f, rb_player.velocity.y, 0.0f);
                rb.AddForce(movement * firespeed);
            }
        }
        else
            firePossible = true;
    }
}
