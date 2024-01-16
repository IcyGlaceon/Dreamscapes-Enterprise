using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    [SerializeField] GameObject collectionParticle;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.GainedCollectables++;
            if (collectionParticle)
            { 
                //Instantiate(collectionParticle, Collectables.transform.position, Collectables.transform.rotation);
            }
            Destroy(gameObject);
        }
    }
}
