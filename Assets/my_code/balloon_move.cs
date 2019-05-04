using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class balloon_move : MonoBehaviour
{
    public GameObject powerup;

    private Color balloonColor;
    private static System.Random rnd = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        transform.position = new Vector3(((float)rnd.Next(-600, 600) / 100), -10f, -0.5f);
        transform.localRotation = Quaternion.identity;
        if (rnd.Next(0, 2) == 1)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, 1f, 1f);
        }

        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0f;
        rb.gravityScale = rnd.Next(-75, -45)/100f; //-0.75 to -0.45

        // decide whether this balloon carries a powerup
        bool hasPackage = rnd.Next(0, 4) == 0;

        //decide color
        balloonColor = randomBrightBalloonColor();

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = balloonColor;

        if (!hasPackage)
        {
            Destroy(powerup);
            powerup = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnBecameInvisible()
    {
        if (powerup)
            Destroy(powerup, 0.4f);
        Destroy(gameObject, 0.4f);
    }


    public void Pop()
    {
        GetComponent<Animator>().SetTrigger("Pop");
        GetComponent<AudioSource>().Play();
        if (powerup)
            LosePackage();
        Destroy(gameObject, 0.25f);
    }

    private void LosePackage()
    {
        Rigidbody2D rb = powerup.GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;
        powerup.transform.parent = null;
        powerup.GetComponent<BoxCollider2D>().isTrigger = true;
        powerup = null;
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
