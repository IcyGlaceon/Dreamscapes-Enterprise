using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    int MaxCollectibles = 15;

    private void OnCollisionEnter2D(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {

        }
    }
}
