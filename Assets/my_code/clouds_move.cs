using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clouds_move : MonoBehaviour
{
    public float speed = 0.1f;
    
    private Material material;
    private Vector2 offset = Vector2.zero;
    
    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
        offset = material.GetTextureOffset("_MainTex");
    }

    // Update is called once per frame
    void Update()
    {
        offset.x += speed * Time.deltaTime;
        material.SetTextureOffset("_MainTex", offset);
    }
}
