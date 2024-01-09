using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slowdown : MonoBehaviour
{
	[SerializeField] BackgroundMovement Movement;
	[SerializeField] float SlowdownAmount = 0.5f;
	private float originalSpeed = 0;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			originalSpeed = Movement.speed;
			Movement.speed = Movement.speed * SlowdownAmount;
			Movement.tempSpeed = Movement.speed;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			Movement.speed = originalSpeed;
			Movement.tempSpeed = originalSpeed;
		}
	}
}
