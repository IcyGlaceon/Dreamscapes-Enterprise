using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EraMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] BackgroundMovement background;
    [SerializeField] float wait = 15;

    Vector2 movementTrans;
    [HideInInspector] public bool move = false;
    float dieTime = 3;

    void Start()
    {
        movementTrans = transform.position;
    }

    void Update()
    {
        if(move)
        {
            wait -= Time.deltaTime;
            if (wait < 0)
            {
                movementTrans += Vector2.right * speed * Time.deltaTime;
                transform.position = movementTrans;
                dieTime -= Time.deltaTime;
                if (dieTime < 0) Destroy(gameObject);
            }
        }
        else
        {
            movementTrans += Vector2.left * background.speed * Time.deltaTime;
            transform.position = movementTrans;
        }
    }
}
