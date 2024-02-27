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
    [Header("Collectables")]
    [SerializeField] TMP_Text collectText;
    [Header("Secret")]
    [SerializeField] GameObject allDreamsParticle;
    [SerializeField] GameObject playerMustache;

    // For timing purposes, the voice lines and faces are arrays on a timer
    private string[] eraVoiceLine1 = { "What is a damaging dream? The ones that take instead of give.", "The dreams that crush dreams.", "You've seen the result. The dwindling.", "A dream cannot sustain itself on the destruction of other dreams for long. It turns into an emptiness that spreads and consumes." };
    private string[] eraVoiceLine2 = { "Not many make it through the mirror maze. Still, I do not know your intentions.", "Many have tried hunting me to gain the power of wishing. None have succeeded.", "I am warning you: those with damaging dreams may not proceed further." };
    private string[] eraVoiceLine3 = { "If your intentions are pure,", "then I will tell you about wish magic. The power to make dreams reality.", "Perhaps, enough constructive dreaming will repair Dreamscapes and Happyton.", "I have prepared a trial for you. Another labyrinth.", "Not a test of your resolve, but a test of your dreams." };
    private string[] eraVoiceLineBeginning = { "I am not as trusting as Magus." };
    private string[] eraVoiceLineSecret = { "If your intentions are...wait...", "When did you get a moustache?", "Oh I see! This is the secret ending to the game!" };
    private string[] polyNoDreams = { "Congratulations! You have no dreams!", "You get the moustache of power!" };
    private string[] polySomeDreams = { "Thank you for collecting some of the lost dreams!" };
    private string[] polyAllDreams = { "Thank you for collecting all of the lost dreams!" };
    private int[] eraFaces1 = { 1, 1, 1, 1 };
    private int[] eraFaces2 = { 1, 1, 0 };
    private int[] eraFaces3 = { 1, 3, 3, 0, 0 };
    private int[] eraFacesSecret = { 1, 1, 2 };

    void Start()
    {
        // Setting variables to default states
        voiceLineText.text = "";
        characterPicture.SetActive(false);
    }

    void Update()
    {
        // Shows the number of collectables the player has in the UI
        collectText.text = GameManager.GainedCollectables.ToString() + " / 9";
    }

    // This is the main function that displays all dialog
    public IEnumerator ShowDialog(string[] dialog, int[] faceNumbers = null, AudioClip voiceLine = null)
    {
        Image characterImage = characterPicture.GetComponent<Image>();
        characterPicture.SetActive(true);
        audioSource.clip = voiceLine;
        audioSource.Play();
        GameManager.currentLevel++;
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
    }

    // This grabs the current currentLevel variable from StopPlayer. This displays the correct set of dialog for each level and spot in each level.
    public void showLevelDialog(int level)
    {
        GameManager.currentLevel = level;
        switch(level)
        {
            // The very beginning of the game
            case 0:
                StartCoroutine(ShowDialog(eraVoiceLineBeginning, eraFaces1, voiceLines[3]));
                break;
            // The ending of level 1
            case 1:
                StartCoroutine(ShowDialog(eraVoiceLine1, eraFaces1, voiceLines[0]));
                break;
            // The ending of level 2
            case 2:
                StartCoroutine(ShowDialog(eraVoiceLine2, eraFaces2, voiceLines[1]));
                break;
            // The ending of level 3
            case 3:
                // Normal ending
                if (!GameManager.moustache) StartCoroutine(ShowDialog(eraVoiceLine3, eraFaces3, voiceLines[2]));
                else
                {
                    // Secret ending if player reaches polly with no dream and gets the moustache of power
                    StartCoroutine(ShowDialog(eraVoiceLineSecret, eraFacesSecret));
                }
                break;
            // Polly dialog. The dialog chages based on the number of dreams the player has when they reach polly
            case 8:
                int[] polyFaces = { 4, 4 };
                if (GameManager.GainedCollectables == 0)
                {
                    StartCoroutine(ShowDialog(polyNoDreams, polyFaces));
                    playerMustache.SetActive(true);
                    GameManager.moustache = true;
                }
                else if (GameManager.GainedCollectables >= 9)
                {
                    StartCoroutine(ShowDialog(polyAllDreams, polyFaces));
                    allDreamsParticle.SetActive(true);
                }
                else if (GameManager.GainedCollectables < 9) StartCoroutine(ShowDialog(polySomeDreams, polyFaces));

                break;
        }
    }
}
