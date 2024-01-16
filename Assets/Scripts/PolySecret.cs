using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DialogSystem;

public class PolySecret : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (GameManager.GainedCollectables == GameManager.MaxCollectibles)
            {
                string line = "Congrats on getting all the dreams";
                //StartCoroutine(DialogSystem.ShowDialog(line));
            }
            else
            {
                string line = "Thank you for collecting these dreams";
                //StartCoroutine(DialogSystem.ShowDialog(line));
            }
        }
    }
}
