using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AutomaticRestart : MonoBehaviour
{
    float Timer = 60;
    public bool RestartUiUp = false;
    [SerializeField] GameObject RestartUI;
    [SerializeField] BackgroundMovement background;

    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 30 && !RestartUiUp)
        { 
            RestartUI.SetActive(true);
            RestartUiUp = true;
        }
        if (Timer <= 0)
        {
            SceneManager.LoadScene("StartScreen");
        }

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

	public void Reset()
	{
        Timer = 60;
        background.maxSpeed = 3;
        RestartUI.SetActive(false);
        RestartUiUp = false;
	}

    public void End()
    {
        Timer = 0;
    }

    
}
