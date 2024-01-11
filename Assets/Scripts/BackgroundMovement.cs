using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class BackgroundMovement : MonoBehaviour
{
    [SerializeField] public float speed = 0;
    [SerializeField] GameObject UI;
    public float tempSpeed = 0;
    Vector2 movementTrans;

    void Start()
    {
        movementTrans = transform.position;
        tempSpeed = speed;
    }

    void Update()
    {
        if (!UI.active)
        {
            movementTrans += Vector2.left * speed * Time.deltaTime;
            transform.position = movementTrans;
            if (tempSpeed > speed)
            {
                speed += 0.05f;
            }
            else if (tempSpeed < speed)
            {
                speed = tempSpeed;
            }
        }
	}

    public void MoveBack()
    {
        transform.position = new Vector2(transform.position.x + 0.3f, 0);
        movementTrans = transform.position;
        tempSpeed = speed;
        speed = -4;
    }
}