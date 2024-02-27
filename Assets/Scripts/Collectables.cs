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

public class Data
{
    public Transform ParticleTransform;
    public Vector3 ParticlePosition;
    public Quaternion ParticleRotation;
    public Vector3 ParticleScale;
    public Vector3 PlayerPosition;
    public Quaternion PlayerRotation;
    public Vector3 PlayerScale;
    
    public Data(Transform transform, Vector3 position, Quaternion rotation, Vector3 scale, Vector3 playerPosition, Quaternion playerRotation, Vector3 playerScale)
	{
		this.ParticleTransform = transform;
		this.ParticlePosition = position;
		this.ParticleRotation = rotation;
		this.ParticleScale = scale;
		PlayerPosition = playerPosition;
		PlayerRotation = playerRotation;
		PlayerScale = playerScale;
	}
}