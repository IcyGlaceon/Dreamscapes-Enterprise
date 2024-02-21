using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AutomaticRestart : MonoBehaviour
{
    // how long until it restarts?
    [SerializeField] float Timer = 60;
    public bool RestartUiUp = false;
    // popup for the player to either restart or 
    [SerializeField] GameObject RestartUI;
    // need the background movement so that we can pause
    [SerializeField] BackgroundMovement background;

    void Update()
    {
        // wow its a countdown
        Timer -= Time.deltaTime;

        // when we get to half of the time, pull the ui up
        if (Timer <= Timer / 2 && !RestartUiUp)
        { 
            RestartUI.SetActive(true);
            RestartUiUp = true;
        }

        // if we run out of time, go back to the start
        if (Timer <= 0)
        {
            SceneManager.LoadScene("StartScreen");
        }

        // debug commands for if you have a keyboard
        if (Input.GetKeyDown(KeyCode.Escape))
        { 
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene("Level1");
        }
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			SceneManager.LoadScene("Level2");
		}
		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			SceneManager.LoadScene("Level3");
		}
	}

    // resume the background movement
    public void ResetSpeed()
    {
        // this is so scalable lol
        background.maxSpeed = 3;
    }

    // reset the timer and remove the popup
	public void Reset()
	{
        Timer = 60;
        RestartUI.SetActive(false);
        RestartUiUp = false;
	}

    // set the timer to 0 which sends you back to the start screen
    public void End()
    {
        Timer = 0;
    }

    
}
