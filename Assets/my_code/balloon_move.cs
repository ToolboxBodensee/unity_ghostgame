using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class balloon_move : MonoBehaviour
{
    public float backRotationSpeed;
    public GameObject powerup;

    private static System.Random rnd = new System.Random();
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        foreach(GameObject wallofdeath in GameObject.FindGameObjectsWithTag("wallofdeath"))
        {
            Physics2D.IgnoreCollision(wallofdeath.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(wallofdeath.GetComponent<Collider2D>(), powerup.GetComponent<Collider2D>());
        }

        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localEulerAngles.z > 180f)
        {
            rb.AddTorque(Time.deltaTime * backRotationSpeed * (transform.localEulerAngles.z-180f)/180f);
        }
        else if (transform.localEulerAngles.z > 0f)
        {
            rb.AddTorque(Time.deltaTime * backRotationSpeed * transform.localEulerAngles.z/180f * -1);
        }
    }

    public void Pop()
    {
        GetComponent<AudioSource>().Play();
        animator.SetTrigger("Pop");
        LosePackage();
        Destroy(gameObject, 0.25f);
    }

    void OnBecameInvisible(){
    
        Destroy(gameObject, 0.25f);
    }

    public void Init()
    {
        transform.position = new Vector3(((float)rnd.Next(-600, 600) / 100), -10f, -0.5f);
        transform.localRotation = Quaternion.identity;
        if (rnd.Next(0, 2) == 1)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, 1f, 1f);
        }

        spriteRenderer.color = randomBrightBalloonColor();

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0f;
        rb.gravityScale = rnd.Next(-50, -10)/100f; //-0.1 to -0.5

        animator.ResetTrigger("Pop");
        
        // decide whether this balloon carries a powerup
        if (rnd.Next(0, 4) > 0)
            LosePackage();
    }

    private Color randomBrightBalloonColor()
    {
        int mainColor = rnd.Next(200, 256);
        int secondaryColor = rnd.Next(0, 106) + rnd.Next(0, 4) * 50;
        int otherColor = rnd.Next(0, 100);
        int[] permutation = {mainColor, secondaryColor, otherColor};
        permute(permutation);

        return new Color(permutation[0]/255f, permutation[1]/255f, permutation[2]/255f);
    }

    public void LosePackage()
    {
        Rigidbody2D rb = powerup.GetComponent<Rigidbody2D>();
        //rb.simulated = true;
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.gravityScale = 0.2f;
        powerup.transform.parent = null;
        powerup.GetComponent<BoxCollider2D>().isTrigger = true;
    }

    private void permute(int[] permutation)
    {
        int i;
        for (i = 0; i < 3; i++) {
            int j = i + rnd.Next(0, 3-i);
            if (i != j)
            {
                int t = permutation[j];
                permutation[j] = permutation[i];
                permutation[i] = t;
            }
        }
    }
}
