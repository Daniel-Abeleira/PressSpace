using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour {

    public TMP_Text score_txt;
    public float score;
    public GameObject gameOver_Pnl;
    public int enemiesKilled;
    public TMP_Text killCount;
    //public TMP_Text highScore;
    public Player player;
    public GameObject pj;
    public bool playerIsDead;


    // Use this for initialization
    void Start () {
        Time.timeScale = 1;
        score = 0;
        enemiesKilled = 0;
        playerIsDead = false;
        pj = GameObject.FindGameObjectWithTag("Player");
        player = pj.GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {

        score_txt.text = score.ToString("0");
        killCount.text = enemiesKilled.ToString();
        score += Time.deltaTime;
        if(player.lifes <= 0)
        {
            Die();
        }
        if(Input.GetKeyDown(KeyCode.Space) && playerIsDead)
        {
            Retry();
        }
	}

    void Die()
    {
        gameOver_Pnl.SetActive(true);
        Time.timeScale = 0;
        playerIsDead = true;
    }

    void Retry()
    {
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1;
        playerIsDead = false;
    }
}
