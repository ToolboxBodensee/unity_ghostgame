using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pl_state : MonoBehaviour
{
    public bool shield = false;
    private float shieldTime = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shield)
        {
            shieldTime -= Time.deltaTime;
            
            float val = ((float)((int)(shieldTime * 1000) % 250) / 500) + 0.25f;
            
            gameObject.GetComponent<SpriteRenderer>().color = new Color(val, 1.0f, val);
            
            if (shieldTime < 0)
                SetShieldEnabled(false);
        }
    }
    
    public void SetShieldEnabled(bool enabled)
    {
        shield = enabled;
        
        if (shield)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0.5f, 1.0f, 0.5f);
            shieldTime = 10.0f;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);
            gameObject.GetComponent<pl_damage>().RefreshHealthAlpha();
        }
    }
    
    public bool GetShieldEnabled()
    {
        return shield;
    }
}
