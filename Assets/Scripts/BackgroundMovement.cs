using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    [SerializeField] float speed = 0;

    Vector2 movementTrans;

    void Start()
    {
        movementTrans = transform.position;
    }

    void Update()
    {
        movementTrans += Vector2.left * speed * Time.deltaTime;
        transform.position = movementTrans;
    }
}