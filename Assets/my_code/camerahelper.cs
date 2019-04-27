using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerahelper : MonoBehaviour
{
    private GameObject pl1;
    private GameObject pl2;

    // Start is called before the first frame update
    void Start()
    {
        pl1 = GameObject.Find("player1");
        pl2 = GameObject.Find("player2");        
    }

    // Update is called once per frame
    void Update()
    {
        float x = pl1.transform.position.x + (pl2.transform.position.x - pl1.transform.position.x) / 2;
        float y = pl1.transform.position.y + (pl2.transform.position.y - pl1.transform.position.y) / 2;
        float z;
        
        if (pl2.transform.position.z < pl1.transform.position.z)
            z = pl1.transform.position.z + (pl2.transform.position.z - pl1.transform.position.z) * 0.75f;
        else
            z = pl1.transform.position.z + (pl2.transform.position.z - pl1.transform.position.z) * 0.25f;
            
        Vector3 pos = new Vector3(x, y, z);
        transform.position = Vector3.Slerp(transform.position, pos, Time.deltaTime * 1.5f);
        
        float roty = /* transform.rotation.y*/ - x * 5f;
        Quaternion rot = Quaternion.Euler(transform.rotation.x, roty, transform.rotation.z);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * 1.5f);
    }
}
