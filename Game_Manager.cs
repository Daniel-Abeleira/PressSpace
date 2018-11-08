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
    public TMP_Text highScore_txt;
    public TMP_Text finalScore_txt;
    public float highScore;
    public Player player;
    public GameObject pj;
    public bool playerIsDead;
    public AudioSource aS1;
    public AudioSource aS2;
    public AudioSource dieAudio;


    // Use this for initialization
    void Start () {
        Time.timeScale = 1;
        highScore_txt.text = PlayerPrefs.GetInt("highScore", 0).ToString("0.0");
        score = 0;
        enemiesKilled = 0;
        playerIsDead = false;
        pj = GameObject.FindGameObjectWithTag("Player");
        player = pj.GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {

        score_txt.text = score.ToString("0.0");
        killCount.text = enemiesKilled.ToString();
        score += Time.deltaTime * 2.5f;
        if(player.lifes <= 0)
        {
            Die();
        }
        if(Input.GetKeyDown(KeyCode.Space) && playerIsDead)
        {
            Retry();
        }
        if(score > PlayerPrefs.GetInt("highScore"))
        {
            PlayerPrefs.SetInt("highScore", (int)Mathf.Round(score));
            highScore_txt.text = PlayerPrefs.GetInt("highScore", 0).ToString("0.0");

        }
	}

    void Die()
    {
        gameOver_Pnl.SetActive(true);
        dieAudio.Play();
        Time.timeScale = 0;
        playerIsDead = true;
        finalScore_txt.text = score.ToString("0.0");
    }

    void Retry()
    {
        SceneManager.LoadScene("Level1");
        int random = Random.Range(1, 2);
        if(random == 1)
        {
            aS1.Play();
        }
        else
        {
            aS2.Play();
        }
        Time.timeScale = 1;
        playerIsDead = false;
    }
}
