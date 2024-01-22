using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float frequency = 20f;
    [SerializeField] float magnitude = 0.5f;

    Vector3 pos;

    void Start()
    {
        pos = transform.position;
    }

    void Update()
    {
        pos += transform.right * Time.deltaTime * moveSpeed;

        transform.position = pos + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;
    }
}
