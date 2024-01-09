using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AutomaticRestart : MonoBehaviour
{
    float Timer = 60;
    bool RestartUiUp = false;
    [SerializeField] GameObject RestartUI;

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
    }

	public void Reset()
	{
        Timer = 60;
        RestartUI.SetActive(false);
        RestartUiUp = false;
	}

    public void End()
    {
        Timer = 0;
    }
}
