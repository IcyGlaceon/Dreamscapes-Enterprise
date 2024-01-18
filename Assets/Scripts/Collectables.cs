using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    [SerializeField] GameObject collectionParticle;
    [SerializeField] GameObject Player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.GainedCollectables++;
            if (collectionParticle)
            {
                Instantiate(collectionParticle, Player.transform.position, collectionParticle.transform.rotation);
			}
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