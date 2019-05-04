using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BalloonManager : NetworkBehaviour
{
    public GameObject balloonPrefab;
    public GameObject powerupPrefab;
    public int numInitialBalloons = 5;
    public float balloonTime = 5.0f;
    public int minBalloonTimeMs = 4000;
    public int maxBalloonTimeMs = 8500;
    public int balloonSpawnCountMax = 3;
    private System.Random rnd = new System.Random();
    private int z;

    // Start is called before the first frame update
    [Server]
    void Start()
    {
        if (!isServer)
        {
            return;
        }
        for(int i=0; i<numInitialBalloons; i++)
            SpawnBalloon();
    }

    // Update is called once per frame
    [Server]
    void Update()
    {
        if (!isServer)
        {
            return;
        }

        balloonTime -= Time.deltaTime;

        if (balloonTime < 0)
        {
            balloonTime = rnd.Next(minBalloonTimeMs,maxBalloonTimeMs)/1000f;
            for (int i=rnd.Next(1,balloonSpawnCountMax+1); i>=0; --i)
            {
                SpawnBalloon();
            }
        }
    }

    private void SpawnBalloon()
    {
        Vector3 pos = new Vector3(((float)rnd.Next(-600, 600) / 100), -10f, z);
        GameObject balloon = Instantiate(balloonPrefab, pos, Quaternion.identity);
        GameObject powerup = Instantiate(powerupPrefab, pos, Quaternion.identity);
        balloon.GetComponent<balloon_move>().powerup = powerup;
        balloon.GetComponent<HingeJoint2D>().connectedBody = powerup.GetComponent<Rigidbody2D>();
        balloon.GetComponent<HingeJoint2D>().enabled = true;
        NetworkServer.Spawn(balloon);
        NetworkServer.Spawn(powerup);
        z++;
    }
}
