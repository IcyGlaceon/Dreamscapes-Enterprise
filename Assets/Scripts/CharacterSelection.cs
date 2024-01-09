using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField] GameObject UI;

    bool isBlue;
    bool isGreen;
    bool isCyan;
    bool isPink;
    bool isRed;
    bool isYellow;

    public void BlueCharacter()
    {
        isBlue = true;
        UI.SetActive(false);
    }

    public bool GetBlue()
    {
        return isBlue;
    }

    public void GreenCharacter()
    {
        isGreen = true;
        UI.SetActive(false);
    }

    public bool GetGreen()
    {
        return isGreen;
    }

    public void CyanCharacter()
    {
        isCyan = true;
        UI.SetActive(false);
    }

    public bool GetCyan()
    {
        return isCyan;
    }

    public void PinkCharacter()
    {
        isPink = true;
        UI.SetActive(false);
    }

    public bool GetPink()
    {
        return isPink;
    }

    public void RedCharacter()
    {
        isRed = true;
        UI.SetActive(false);
    }

    public bool GetRed()
    {
        return isRed;
    }

    public void YellowCharacter()
    {
        isYellow = true;
        UI.SetActive(false);
    }

    public bool GetYellow()
    {
        return isYellow;
    }
}
