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
    float slowSpeed;
    public float backwardsSpeed;

    void Start()
    {
        SetupTexture();
        moveSpeed = -moveSpeed;
        originalSpeed = moveSpeed;
        slowSpeed = moveSpeed * SlowdownAmount;
        backwardsSpeed = moveSpeed * -1.3f;
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

        if (BGMovement.slow == false)
        {
            if (BGMovement.bouncedBack == true)
            {
                moveSpeed = backwardsSpeed;
            }
            else
            {
                if (BGMovement.bouncedBack == false && moveSpeed > originalSpeed)
                {
                    Debug.Log("aaaaaaa");
                    moveSpeed -= (originalSpeed / 60);
                }
                else
                {
                    moveSpeed = originalSpeed;
                }
                
            }
        }
        else
        {
            moveSpeed = slowSpeed;
        }

        if(BGMovement.speed == 0)
        {
            moveSpeed = 0;
        }
        else
        {
            moveSpeed = originalSpeed;
        }
    }
}
