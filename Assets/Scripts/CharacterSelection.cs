using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField] GameObject UI;

    //The following functions change the players color

    public void BlueCharacter()
    {
        GameManager.blueCharacter = true;
        SceneManager.LoadScene("Tutorial");
    }

    public void GreenCharacter()
    {
        GameManager.greenCharacter = true;
        SceneManager.LoadScene("Tutorial");
    }

    public void CyanCharacter()
    {
        GameManager.cyanCharacter = true;
        SceneManager.LoadScene("Tutorial");
    }

    public void PinkCharacter()
    {
        GameManager.pinkCharacter = true; 
        SceneManager.LoadScene("Tutorial");
    }

    public void RedCharacter()
    {
        GameManager.redCharacter = true;
        SceneManager.LoadScene("Tutorial");
    }

    public void YellowCharacter()
    {
        GameManager.yellowCharacter = true;
        SceneManager.LoadScene("Tutorial");
    }

    public void Start()
    {
        //These reset the players color

        GameManager.GainedCollectables = 0;
        GameManager.moustache = false;
        GameManager.blueCharacter = false;
        GameManager.cyanCharacter = false;
        GameManager.yellowCharacter = false;
        GameManager.redCharacter = false;
        GameManager.pinkCharacter = false;
        GameManager.greenCharacter = false;
    }

}
