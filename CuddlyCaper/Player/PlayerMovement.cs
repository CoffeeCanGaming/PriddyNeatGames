using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool isGrounded, checkR, checkL,playWalk;
    public Animator anim;
    public Rigidbody2D rb;
    public CapsuleCollider2D col;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ClipL();
        ClipR();
        IsGrounded();


        if (Input.GetKey(KeyCode.D) && (checkR))
        {
            
            anim.SetBool("RunRight", true);
            rb.velocity = new Vector2(2, rb.velocity.y);
        }

        if (Input.GetKey(KeyCode.A) && checkL)
        {
            
            anim.SetBool("RunLeft", true);
            rb.velocity = new Vector2(-2, rb.velocity.y);
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            anim.SetBool("RunRight", false);
            anim.SetBool("RunLeft", false);
        }


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, 3.5f);
        }
        if (anim.GetBool("Jump") && Input.GetKey(KeyCode.A))
        {
            anim.SetBool("RunLeft", false);
            anim.SetBool("JumpLeft", true);
        }
        if (anim.GetBool("Jump") && Input.GetKey(KeyCode.D))
        {
            anim.SetBool("RunRight", false);
            anim.SetBool("JumpRight", true);
        }

        if (isGrounded)
        {
            anim.SetBool("Jump", false);
            anim.SetBool("JumpLeft", false);
            anim.SetBool("JumpRight", false);
        }


    }
    public bool ClipL()
    {
        RaycastHit2D hitLHi = Physics2D.Raycast(new Vector2(rb.transform.position.x - .2f, rb.transform.position.y + .2f), -Vector3.forward);
        RaycastHit2D hitLow = Physics2D.Raycast(new Vector2(rb.transform.position.x - .2f, rb.transform.position.y - .2f), -Vector3.forward);

        if (hitLHi.collider != null || hitLow.collider != null)
        {

            return checkL = false;

        }
        else
        {
            return checkL = true;
        }
    }
    public bool ClipR()
    {
        RaycastHit2D hitRHi = Physics2D.Raycast(new Vector2(rb.transform.position.x + .2f, rb.transform.position.y + .2f), -Vector3.forward);
        RaycastHit2D hitRLow = Physics2D.Raycast(new Vector2(rb.transform.position.x + .2f, rb.transform.position.y - .2f), -Vector3.forward);

        if (hitRHi.collider != null || hitRLow.collider != null)
        {

            return checkR = false;

        }
        else
        {
            return checkR = true;
        }
    }
    public bool IsGrounded()
    {
        RaycastHit2D hitG = Physics2D.Raycast(new Vector2(rb.transform.position.x, rb.transform.position.y - .25f), -Vector3.forward);

        if (hitG.collider != null)
        {
            anim.SetBool("Jump", false);
            anim.SetBool("Grounded", true);
            return isGrounded = true;
        }
        else
        {
            anim.SetBool("Jump", true);
            anim.SetBool("Grounded", false);
            return isGrounded = false;
        }
    }


}
