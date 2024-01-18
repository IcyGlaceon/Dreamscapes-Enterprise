using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] Movement movement;
    [SerializeField] BackgroundMovement BGMovement;
    [SerializeField] float SlowdownAmount = 0.5f;

    float singleTextureWidth;
    float originalSpeed;
    public float slowSpeed;

    void Start()
    {
        SetupTexture();
        moveSpeed = -moveSpeed;
        originalSpeed = moveSpeed;
        slowSpeed = moveSpeed * SlowdownAmount;
    }

    void SetupTexture()
    {
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        singleTextureWidth = sprite.texture.width / sprite.pixelsPerUnit;
    }

    void Scroll()
    {
        float delta = moveSpeed * Time.deltaTime;
        transform.position += new Vector3(delta, 0, 0);
    }

    void CheckReset()
    {
        if ((Mathf.Abs(transform.position.x) - singleTextureWidth) > 0)
        {
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
        }
    }

    private void Update()
    {
        Scroll();
        CheckReset();

        if (BGMovement.slow == true)// && moveSpeed != slowSpeed)
        {
            moveSpeed = slowSpeed;
        }

        if (BGMovement.slow == false && moveSpeed != originalSpeed)
        {
            moveSpeed = originalSpeed;
        }

        if (BGMovement.bouncedBack == true)
        {
            moveSpeed = 4;
        } 

        if (BGMovement.bouncedBack == false)
        {
            moveSpeed = originalSpeed;
        }
    }
}
