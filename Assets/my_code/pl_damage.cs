using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pl_damage : MonoBehaviour
{
    public int playerNumber;
    public float health;
    
    private GameObject scoreboard;
    private GameObject winText;
    private GameObject title;
    private long waitTime;
    
    private string fullscore = " ⅠⅡⅢⅣⅤⅥⅦⅧⅨⅩ"; // this was funny but it didn't work in webgl-mode
    private string[] scorestrings = new string[] {" ", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X", "XI",  "XII", "XIII", "XIV", "XV", "XVI", "XVII", "XVIII", "XIX", "XX"};

    public GameObject winsound;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;   // health in percent
        
        scoreboard = GameObject.Find("Scoreboard" + playerNumber);
        winText = GameObject.Find("WinText");
        title = GameObject.Find("GameTitle");
        updateScoreboard();
        waitTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (waitTime != 0)
        {
            if ((DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) - waitTime > 5500)
            {
                resetGame();
            }
        }
    }
    
    public void RefreshHealthAlpha()
    {
        Color tmp = GetComponent<SpriteRenderer>().color;
        tmp.a = health / 100.0f;
        GetComponent<SpriteRenderer>().color = tmp;
    }

    public void ApplyDamage(float val)
    {
        if (GetComponent<pl_state>().GetShieldEnabled() && val > 0.0f)
        {
            GetComponent<pl_state>().SetShieldEnabled(false);
            return;
        }

        health -= val;

        if (health <= 0.0f)
        {
            winText.GetComponent<Text>().text = "PLAYER " + (playerNumber == 1 ? 2 : 1) + " WINS";
            title.GetComponent<Text>().color = new Color(title.GetComponent<Text>().color.r, title.GetComponent<Text>().color.g, title.GetComponent<Text>().color.b, 200/255f);
            waitTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            Time.timeScale = 0.0f;

            foreach(AudioSource sound in winsound.GetComponents<AudioSource>())
                sound.Play();
        }

        GetComponent<AudioSource>().Play();

        RefreshHealthAlpha();
        updateScoreboard();
    }

    private void updateScoreboard()
    {
        Color tmp = GetComponent<SpriteRenderer>().color;
        //scoreboard.GetComponent<Text>().text = fullscore.Substring((int)(tmp.a * 10 + 0.5f), 1);
        scoreboard.GetComponent<Text>().text = scorestrings[(int)(health / 10 + 0.5f)];
    }

    private void resetGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
