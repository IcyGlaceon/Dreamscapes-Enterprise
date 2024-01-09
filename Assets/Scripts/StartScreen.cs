using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public void CharacterSelection()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
