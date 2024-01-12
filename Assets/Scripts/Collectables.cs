using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
   

    private void OnTrigger2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameManager.GainedCollectables++;
            Destroy(gameObject);
        }
    }
}
