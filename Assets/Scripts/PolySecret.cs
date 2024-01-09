using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolySecret : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (gameManager.GainedCollectables == gameManager.MaxCollectibles)
            {
                // Implement Poly saying "Congrats on getting all the dreams"
            }
            else
            {
                // Implement Poly saying "Thank you for collecting these dreams"
            }
        }
    }
}
