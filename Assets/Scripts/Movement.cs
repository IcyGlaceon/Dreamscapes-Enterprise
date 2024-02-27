using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Rigidbody2D player;
    [SerializeField] BackgroundMovement world;
    [SerializeField] Animator anim;
    [SerializeField] CharacterSelection selection;
    [SerializeField] AutomaticRestart restart;
    [SerializeField] AudioSource jumpSound;

    bool isGrounded = false;
    public float storedPosition = 0;

    [SerializeField] Transform ground;

    // Start is called before the first frame update
    void Start()
    {
        storedPosition = player.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        //Moves the world when the player is moving

        if (player.position.x - storedPosition < -0.4 || player.position.x - storedPosition > 0.4)
        {
			if (world != null)
            {
                world.MoveBack();
                isGrounded = false;
            }
            player.position = new Vector2(storedPosition, player.position.y);
        }
        player.velocity = new Vector2(0, player.velocity.y);

        //This checks if the player has hit the ground

        RaycastHit2D groundHit = Physics2D.Raycast(transform.position, Vector2.down, 1f, LayerMask.GetMask("Ground"));
        if (groundHit.collider != null)
        {
		    if (groundHit.collider.gameObject.tag == "Ground")
            {
                onGround();
            }
        }
        else 
        {
            //Makes the player fall
            if (player.velocity.y <= -1)
            {
                isFalling();
            }
        }
        Debug.Log(anim.GetCurrentAnimatorClipInfo(0)[0].clip.name);
        
        //Changes the players color

        anim.SetBool("IsBlue", GameManager.blueCharacter);
        anim.SetBool("IsGreen", GameManager.greenCharacter);
        anim.SetBool("IsCyan", GameManager.cyanCharacter);
        anim.SetBool("IsRed", GameManager.redCharacter);
        anim.SetBool("IsPink", GameManager.pinkCharacter);
        anim.SetBool("IsYellow", GameManager.yellowCharacter);

        //Makes the player jump
        if(Input.GetMouseButtonDown(0) && !restart.RestartUiUp && world.maxSpeed != 0)
        {
            Jump();
            restart.Reset();
        }

        if(restart.RestartUiUp)
        {
            world.maxSpeed = 0;
        }
    }

    public void Jump()
    {
        //Checks if the player is on the ground and not falling

        if (isGrounded && player.velocity.y == 0)
        {
            jumpSound.Play();
            anim.SetTrigger("Jump");
            anim.SetBool("IsRunning", false);
            player.velocity = (Vector2.up * 8);
            isGrounded = false;
        }
    }

    public void onGround()
    {
        //Makes the player be on the ground

        isGrounded = true;
        anim.SetBool("IsRunning", true);
        anim.SetBool("IsFalling", false);
    }

    public void isFalling()
    {
        //Makes the player fall

        isGrounded = false;
        anim.SetBool("IsRunning", false);
        anim.SetBool("IsFalling", true);
    }
}