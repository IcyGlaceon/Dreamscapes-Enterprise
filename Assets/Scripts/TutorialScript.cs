using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialScript : MonoBehaviour
{
    // If the player clicks the screen, it transitions to the first level
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) SceneManager.LoadSceneAsync("Level1");
    }
}
