using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonManager : MonoBehaviour
{
    public GameObject balloonPrefab;
    public int numInitialBalloons;
    private float balloonTime = 5.0f;
    private System.Random rnd = new System.Random();
    private int z;
    
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<numInitialBalloons; i++)
            SpawnBalloon();
    }

    // Update is called once per frame
    void Update()
    {
        balloonTime -= Time.deltaTime;
        
        if (balloonTime < 0)
        {
            balloonTime = (float)rnd.Next(1,4) - 0.5f;
            SpawnBalloon();
        }
    }
    
    public void SpawnBalloon()
    {
        Vector3 pos = new Vector3(((float)rnd.Next(-600, 600) / 100), -10f, z);
        Instantiate(balloonPrefab, pos, Quaternion.identity);
        z++;
    }
}
