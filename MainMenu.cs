using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public bool tutorialStarted;
    public GameObject tutorialPnl;
    public float timeLeftUse;

	// Use this for initialization
	void Start () {
        tutorialPnl.SetActive(false);
        tutorialStarted = false;
        timeLeftUse = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            tutorialStarted = true;
            tutorialPnl.SetActive(true);
        }
        if(tutorialStarted)
        {
            if (Input.GetKeyDown(KeyCode.Space) && timeLeftUse <= 0)
            {
                SceneManager.LoadScene("Level1");
            }
            else
            {
                timeLeftUse -= Time.deltaTime;
            }
        }
	}
}
