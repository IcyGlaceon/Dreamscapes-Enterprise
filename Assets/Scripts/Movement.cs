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

    bool isGrounded = false;
    float storedPosition = 0;
    private float jumpTime = 0;

    [SerializeField] Transform ground;

    // Start is called before the first frame update
    void Start()
    {
        storedPosition = player.position.x;
        anim.SetBool("IsBlue", true);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(ground.position, -Vector2.up);

        Debug.Log(player.position.x - storedPosition);
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

        if(player.velocity.y <= -1)
        {
            isFalling();
        }

        if(hit.collider.tag == "Platform")
        {
            onGround();
        }


        RaycastHit2D groundHit = Physics2D.Raycast(transform.position, Vector2.down, 0.7f, LayerMask.GetMask("Ground"));
        if (groundHit.collider != null)
        {
		    if (groundHit.collider.gameObject.tag == "Ground")
            {
                onGround();
            }
        }
        else 
        {
            isFalling();
        }

        //anim.SetBool("IsBlue", GameManager.blueCharacter);
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
