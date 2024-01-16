using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class BackgroundMovement : MonoBehaviour
{
    [SerializeField] public float speed = 0;
    [SerializeField] GameObject UI;
    public bool slow = false;
    public float slowSpeed;
    private float maxSpeed;
    Vector2 movementTrans;

    void Start()
    {
        movementTrans = transform.position;
        slowSpeed = speed / 2;
        maxSpeed = speed;
    }

    void Update()
    {
        if (!UI.active)
        {
            movementTrans += Vector2.left * speed * Time.deltaTime;
            transform.position = movementTrans;
            if (maxSpeed > speed)
            {
                if (slow)
                {
                    if (slowSpeed > speed)
                    {
                        speed += 0.05f;
                    }
                }
                else
                {
                    speed += 0.05f;
                }
            }
            else if (maxSpeed < speed)
            {
                speed = maxSpeed;
            }
        }
	}

    public void MoveBack()
    {
        if(speed == maxSpeed) 
        { 
            transform.position = new Vector2(transform.position.x + 0.3f, 0);
            movementTrans = transform.position;
            speed = -4;
        }
    }
}