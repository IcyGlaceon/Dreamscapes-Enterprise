using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPlayer : MonoBehaviour
{
	[SerializeField] BackgroundMovement Background;
	[Header("Dialog")]
	[SerializeField] DialogSystem dialogSystem;
	[SerializeField] int levelNumber;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			Background.maxSpeed = 0;
			dialogSystem.showLevelDialog(levelNumber);
		}
	}
} 
