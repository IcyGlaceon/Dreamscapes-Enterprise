using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField] GameObject UI;

    public void BlueCharacter()
    {
        GameManager.blueCharacter = true;
        SceneManager.LoadScene(0);
    }

    public void GreenCharacter()
    {
        GameManager.greenCharacter = true;
        SceneManager.LoadScene(0);
    }

    public void CyanCharacter()
    {
        GameManager.cyanCharacter = true;
        SceneManager.LoadScene(0);
    }

    public void PinkCharacter()
    {
        GameManager.pinkCharacter = true; 
        SceneManager.LoadScene(0);
    }

    public void RedCharacter()
    {
        GameManager.redCharacter = true;
        SceneManager.LoadScene(0);
    }

    public void YellowCharacter()
    {
        GameManager.yellowCharacter = true;
        SceneManager.LoadScene(0);
    }
    
}
