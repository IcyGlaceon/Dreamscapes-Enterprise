using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
   

    private void OnCollisionEnter2D(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameManager.GainedCollectables++;
        }
    }
}
