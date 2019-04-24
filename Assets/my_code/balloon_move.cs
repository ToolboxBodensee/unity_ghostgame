using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class balloon_move : MonoBehaviour
{
    private static System.Random rnd = new System.Random();
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        foreach(GameObject wallofdeath in GameObject.FindGameObjectsWithTag("wallofdeath"))
            Physics2D.IgnoreCollision(wallofdeath.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        Respawn();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Pop()
    {
        animator.SetTrigger("Pop");
        Invoke("Respawn", 0.25f);
    }

    void OnBecameInvisible() {
        Invoke("Respawn", 0.25f);
    }

    public void Respawn()
    {
        transform.position = new Vector3((float)rnd.Next(-6, 6), -10f, -0.5f);

        int mainColor = rnd.Next(200, 256);
        int secondaryColor = rnd.Next(0, 106) + rnd.Next(0, 4) * 50;
        int otherColor = rnd.Next(0, 100);
        int[] permutation = {mainColor, secondaryColor, otherColor};
        permute(permutation);
        spriteRenderer.color = new Color(permutation[0]/255f, permutation[1]/255f, permutation[2]/255f);

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.zero;
        rb.gravityScale = (float)(rnd.Next(-10, -1))/100; //-0.01 to -0.1

        animator.ResetTrigger("Pop");
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
