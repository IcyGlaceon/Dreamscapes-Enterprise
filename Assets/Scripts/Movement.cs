using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Rigidbody2D player;
    [SerializeField] Animator anim;
    [SerializeField] CharacterSelection selection;

    bool isGrounded = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("IsBlue", selection.GetBlue());
        anim.SetBool("IsGreen", selection.GetGreen());
        anim.SetBool("IsCyan", selection.GetCyan());
        anim.SetBool("IsRed", selection.GetRed());
        anim.SetBool("IsPink", selection.GetPink());
        anim.SetBool("IsYellow", selection.GetYellow());
    }

    public void Jump()
    {
        if (isGrounded)
        {
            player.velocity = (Vector2.up * 10);
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
