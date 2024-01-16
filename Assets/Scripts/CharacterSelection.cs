using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField] GameObject UI;

    public void BlueCharacter()
    {
        ScenesTrans.blueCharacter = true;
        SceneManager.LoadScene(0);
    }

    public void GreenCharacter()
    {
        ScenesTrans.greenCharacter = true;
        SceneManager.LoadScene(0);
    }

    public void CyanCharacter()
    {
        ScenesTrans.cyanCharacter = true;
        SceneManager.LoadScene(0);
    }

    public void PinkCharacter()
    {
        ScenesTrans.pinkCharacter = true; 
        SceneManager.LoadScene(0);
    }

    public void RedCharacter()
    {
        ScenesTrans.redCharacter = true;
        SceneManager.LoadScene(0);
    }

    public void YellowCharacter()
    {
        ScenesTrans.yellowCharacter = true;
        SceneManager.LoadScene(0);
    }
    
}
