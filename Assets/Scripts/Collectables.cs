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
                Instantiate(collectionParticle, FindObjectOfType<Movement>().transform.position, collectionParticle.transform.rotation);
            }
            Destroy(gameObject);
        }
    }
}
