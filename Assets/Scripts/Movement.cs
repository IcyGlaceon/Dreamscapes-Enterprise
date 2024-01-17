using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Rigidbody2D player;
    [SerializeField] BackgroundMovement world;
    [SerializeField] Animator anim;
    [SerializeField] CharacterSelection selection;
    [SerializeField] GameObject UI;

    bool isGrounded = false;
    float storedPosition = 0;

    // Start is called before the first frame update
    void Start()
    {
        storedPosition = player.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.x - storedPosition < -0.3 || player.position.x - storedPosition > 0.3)
        {
            if (world != null)
            {
                world.MoveBack();
                isGrounded = false;
            }
            player.position = new Vector2(storedPosition, player.position.y);
        }
        player.velocity = new Vector2(0, player.velocity.y);

        if (player.velocity.y < 0)
        {
            isGrounded = false;
        }

        anim.SetBool("IsBlue", GameManager.blueCharacter);
        anim.SetBool("IsGreen", GameManager.greenCharacter);
        anim.SetBool("IsCyan", GameManager.cyanCharacter);
        anim.SetBool("IsRed", GameManager.redCharacter);
        anim.SetBool("IsPink", GameManager.pinkCharacter);
        anim.SetBool("IsYellow", GameManager.yellowCharacter);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            player.velocity = (Vector2.up * 8);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}
