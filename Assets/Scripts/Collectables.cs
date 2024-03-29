using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    // collectionParticle = the particle used for when the player grabs the collectable
    // Player = player object in world
    [SerializeField] GameObject collectionParticle;
    [SerializeField] GameObject Player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Checks to see if the Collider belongs to Player
        if (collision.gameObject.tag == "Player")
        {
            // Plays collection sounds
            GameManager.collectSound.Play();
            // Increments the total gained collectables in the game manager
            GameManager.GainedCollectables++;
            // Checks to see if there is a valid particle for collection
            if (collectionParticle)
            {
                // creates the particle
                Instantiate(collectionParticle, Player.transform.position, collectionParticle.transform.rotation);
			}
            // destroys the collectable
            Destroy(gameObject);
        }
    }
}