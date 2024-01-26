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

    bool isGrounded = false;
    public float storedPosition = 0;
    private float jumpTime = 0;

    [SerializeField] Transform ground;

    // Start is called before the first frame update
    void Start()
    {
        storedPosition = player.position.x;
        //anim.SetBool("IsBlue", true);
    }

    // Update is called once per frame
    void Update()
    {
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
            if (player.velocity.y <= -1)
            {
                isFalling();
            }
        }
        Debug.Log(anim.GetCurrentAnimatorClipInfo(0)[0].clip.name);
        

        anim.SetBool("IsBlue", GameManager.blueCharacter);
        anim.SetBool("IsGreen", GameManager.greenCharacter);
        anim.SetBool("IsCyan", GameManager.cyanCharacter);
        anim.SetBool("IsRed", GameManager.redCharacter);
        anim.SetBool("IsPink", GameManager.pinkCharacter);
        anim.SetBool("IsYellow", GameManager.yellowCharacter);

        if(Input.GetMouseButtonDown(0) && !restart.RestartUiUp)
        {
            Jump();
            restart.Reset();
        }

        if(restart.RestartUiUp)
        {
            world.speed = 0;
        }
    }

    public void Jump()
    {
        if (isGrounded && player.velocity.y == 0)
        {
            anim.SetTrigger("Jump");
            anim.SetBool("IsRunning", false);
            player.velocity = (Vector2.up * 8);
            isGrounded = false;
        }
    }

    public void onGround()
    {
        isGrounded = true;
        anim.SetBool("IsRunning", true);
        anim.SetBool("IsFalling", false);
    }

    public void isFalling()
    {
        isGrounded = false;
        anim.SetBool("IsRunning", false);
        anim.SetBool("IsFalling", true);
    }
}