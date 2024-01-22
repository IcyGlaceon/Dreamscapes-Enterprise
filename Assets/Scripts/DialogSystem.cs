using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    [Header("Dialog")]
    [SerializeField] TMP_Text voiceLineText;
    [SerializeField] GameObject characterPicture;
    [SerializeField] Sprite[] characterSprites;
    [SerializeField] float speed;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] voiceLines;
    [Header("Stoping")]
    [SerializeField] GameObject stopPlayer;
    [Header("Collectables")]
    [SerializeField] TMP_Text collectText;

    private string[] eraVoiceLine1 = { "Not many make it through the mirror maze. Still, I do not know your intentions.", "Many have tried hunting me to gain the power of wishing. None have succeeded.", "I am warning you: those with damaging dreams may not proceed further." };
    private string[] eraVoiceLine2 = { "What is a damaging dream? The ones that take instead of give.", "The dreams that crush dreams.", "You've seen the result. The dwindling.", "A dream cannot sustain itself on the destruction of other dreams for long. It turns into an emptiness that spreads and consumes." };
    private string[] eraVoiceLine3 = { "If your intentions are pure,", "then I will tell you about wish magic. The power to make dreams reality.", "Perhaps, enough constructive dreaming will repair Dreamscapes and Happyton.", "I have prepared a trial for you. Another labyrinth.", "Not a test of your resolve, but a test of your dreams." };
    private string[] eraVoiceLineBeginning = { "I am not as trusting as Magus." };
    private int[] eraFaces1 = { 1, 1, 0 };
    private int[] eraFaces2 = { 1, 1, 1, 1 };
    private int[] eraFaces3 = { 1, 3, 3, 0, 0 };

    private int currentLevel;

    void Start()
    {
        voiceLineText.text = "";
        characterPicture.SetActive(false);
        //StartCoroutine(ShowDialog(eraVoiceLine1, eraFaces1, voiceLines[0]));
    }

    void Update()
    {
        collectText.text = GameManager.GainedCollectables.ToString();
    }

    public IEnumerator ShowDialog(string[] dialog, int[] faceNumbers = null, AudioClip voiceLine = null)
    {
        Image characterImage = characterPicture.GetComponent<Image>();
        characterPicture.SetActive(true);
        audioSource.clip = voiceLine;
        audioSource.Play();
        currentLevel++;
        for (int i = 0; i < dialog.Length; i++)
        {
            characterImage.sprite = characterSprites[faceNumbers[i]];
            foreach (char letter in dialog[i])
            {
                voiceLineText.text += letter;
                yield return new WaitForSeconds(speed);
            }
            yield return new WaitForSeconds(1.5f);
            voiceLineText.text = "";
        }
        characterPicture.SetActive(false);
        SceneManager.LoadSceneAsync("Level" +  currentLevel);
    }

    public void showLevelDialog(int level)
    {
        currentLevel = level;
        switch(level)
        {
            case 0:
                StartCoroutine(ShowDialog(eraVoiceLineBeginning, eraFaces1, voiceLines[3]));
                break;
            case 1:
                StartCoroutine(ShowDialog(eraVoiceLine1, eraFaces1, voiceLines[0]));
                break;
            case 2:
                StartCoroutine(ShowDialog(eraVoiceLine2, eraFaces2, voiceLines[1]));
                break;
            case 3:
                StartCoroutine(ShowDialog(eraVoiceLine3, eraFaces3, voiceLines[2]));
                break;
        }
    }
}
