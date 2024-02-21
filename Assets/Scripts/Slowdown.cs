using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slowdown : MonoBehaviour
{
	// needed to change the speed
	[SerializeField] BackgroundMovement Movement;
	// this shouldnt be serialized. its always .5
	[SerializeField] float SlowdownAmount = 0.5f;
	// needed to fix the speed
	private float originalSpeed = 0;

	// slow the world
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			originalSpeed = Movement.speed;
			Movement.speed = Movement.speed * SlowdownAmount;
			Movement.slow = true;
		}
	}

	// resume speed
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			Movement.speed = originalSpeed;
			Movement.slow = false;
			Movement.bounceTime = 0.2f;
		}
	}
}
