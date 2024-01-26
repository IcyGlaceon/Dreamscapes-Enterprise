using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class BackgroundMovement : MonoBehaviour
{
    [SerializeField] public float speed = 0;
    [SerializeField] GameObject UI;
    public bool slow = false;
    public float slowSpeed;
    public float maxSpeed;
    public bool bouncedBack = false;
	public float bounceTime = 0;
	Vector2 movementTrans;
    private int count = 0;
    private float prevSpeed = 0;

    void Start()
    {
        movementTrans = transform.position;
        slowSpeed = speed / 2;
        maxSpeed = speed;
    }

    void Update()
    {
        movementTrans += Vector2.left * speed * Time.deltaTime;
        transform.position = movementTrans;
        if (maxSpeed > speed) // slow or bounced back
        {
            if (slow) // if we are in a slow region
            {
                if (slowSpeed > speed) // go up to slow speed
                {
                    speed += 0.05f;
                }
                if (slowSpeed < speed) 
                { 
                    speed = slowSpeed;
                }
            }
            else // otherwise go back to max speed
            {
                speed += 0.05f;
                bouncedBack = false;
            }
        }
        else if (maxSpeed < speed) // make sure that speed is capped
        {
            speed = maxSpeed;
        }
        bounceTime -= Time.deltaTime;

        if (prevSpeed > speed && speed > -3.5 && speed != slowSpeed) 
        {
            speed = prevSpeed;
        }
        prevSpeed = speed;
    }

    public void MoveBack()
    {
        count++;
        if(speed == maxSpeed && bounceTime <= 0) 
        {
			bouncedBack = true;
            transform.position = new Vector2(transform.position.x + 0.3f, 0);
            movementTrans = transform.position;
            speed = -4;
        }
    }
}