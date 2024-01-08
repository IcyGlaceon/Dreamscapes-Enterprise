using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolySecret : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            /*
             * if (player.collectables = MaxCollectables)
             * {
             *      - Text about getting all the dreams -
             * }
             * else 
             * {
             *      - Text about getting some dreams -
             * }
             */
        }
    }
}
