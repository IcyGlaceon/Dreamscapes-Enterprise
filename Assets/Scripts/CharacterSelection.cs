using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField] Animator playerAnim;

    bool isBlue;
    bool isGreen;
    bool isCyan;
    bool isPink;
    bool isRed;
    bool isYellow;

    public void BlueCharacter()
    {
        isBlue = true;
        SceneManager.LoadScene("SampleScene");

        playerAnim.SetBool("IsBlue", isBlue);

        //UI.SetActive(false);
    }

    public bool GetBlue()
    {
        return isBlue;
    }

    public void GreenCharacter()
    {
        isGreen = true;
        SceneManager.LoadScene("SampleScene");

        playerAnim.SetBool("IsGreen", isGreen);
        //UI.SetActive(false);
    }

    public bool GetGreen()
    {
        return isGreen;
    }

    public void CyanCharacter()
    {
        isCyan = true;
        SceneManager.LoadScene("SampleScene");

        playerAnim.SetBool("IsCyan", isCyan);
        //UI.SetActive(false);
    }

    public bool GetCyan()
    {
        return isCyan;
    }

    public void PinkCharacter()
    {
        isPink = true;
        SceneManager.LoadScene("SampleScene");

        playerAnim.SetBool("IsPink", isPink);
        //UI.SetActive(false);
    }

    public bool GetPink()
    {
        return isPink;
    }

    public void RedCharacter()
    {
        isRed = true;
        SceneManager.LoadScene("SampleScene");

        playerAnim.SetBool("IsRed", isRed);
        //UI.SetActive(false);
    }

    public bool GetRed()
    {
        return isRed;
    }

    public void YellowCharacter()
    {
        isYellow = true;
        SceneManager.LoadScene("SampleScene");

        playerAnim.SetBool("IsYellow", isYellow);
        //UI.SetActive(false);
    }

    public bool GetYellow()
    {
        return isYellow;
    }
}
