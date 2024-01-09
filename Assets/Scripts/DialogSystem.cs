using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    [SerializeField] TMP_Text voiceLineText;
    [SerializeField] Image characterPicture;
    [SerializeField] float speed;

    private string[] eraVoiceLines = {"Not many make it through the mirror maze. Still, I do not know your intentions. Many have tried hunting me to gain the power of wishing. None have succeeded. I am warning you: those with damaging dreams may not proceed further.",
        "What is a damaging dream? The ones that take instead of give. The dreams that crush dreams. You've seen the result. The dwindling. A dream cannot sustain itself on the destruction of other dreams for long. It turns into an emptiness that spreads and consumes.",
        "I am not as trusting as Magus. If your intentions are pure, then I will tell you about wish magic. The power to make dreams reality. Perhaps, enough constructive dreaming will repair Dreamscapes and Happyton. I have prepared a trial for you. Another labyrinth Not a test of your resolve, but a test of your dreams."};

    void Start()
    {
        voiceLineText.text = "";
        StartCoroutine(ShowDialog(eraVoiceLines[0]));
    }

    void Update()
    {

    }

    private IEnumerator ShowDialog(string dialog)
    {
        dialog.ToCharArray();
        float letterSpeed = speed;

        foreach (char letter in dialog)
        {
            letterSpeed = speed;
            voiceLineText.text += letter;
            yield return new WaitForSeconds(speed);
        }
    }
}
