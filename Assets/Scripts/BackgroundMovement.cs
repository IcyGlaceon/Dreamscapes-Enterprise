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
    // ignore that its serialized, its 3 always
    [SerializeField] public float speed = 0;
    [SerializeField] GameObject UI;
    // are we in a slow region
    public bool slow = false;
    // its half of speed
    public float slowSpeed;
    // idk this was needed for either bounceback or slowdown
    public float maxSpeed;
    // if we have bounced back
    public bool bouncedBack = false;
    // idk what this does
	public float bounceTime = 0;
    // vector for moving
	Vector2 movementTrans;
    // this is because the bounceback was weird and without it you would randomly bounce back after jumping after falling into a slow region after getting bounced back
    // yes its as weird as it sounds
    private float prevSpeed = 0;

    void Start()
    {
        // just set things
        movementTrans = transform.position;
        slowSpeed = speed / 2;
        maxSpeed = speed;
    }

    void Update()
    {
        // moving the backgound
        movementTrans += Vector2.left * speed * Time.deltaTime;
        // set the backgound position
        transform.position = movementTrans;
        if (maxSpeed > speed) // slow or bounced back
        {
            if (slow) // if we are in a slow region
            {
                if (slowSpeed > speed) // if we bounce back in a slow region (which shouldnt be possible)
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
        bounceTime -= Time.deltaTime; // idk man this still means nothing to me

        // this is the weird bounceback bug. just leave it be. its a special snowflake
        if (prevSpeed > speed && speed > -3.5 && speed != slowSpeed && speed != 0) 
        {
            speed = prevSpeed;
        }
        prevSpeed = speed;
    }

    public void MoveBack()
    {
        // move the world back so that the player gets out of the floor
        if(speed == maxSpeed && bounceTime <= 0) 
        {
			bouncedBack = true;
            transform.position = new Vector2(transform.position.x + 0.3f, 0);
            movementTrans = transform.position;
            speed = -4;
        }
    }
}