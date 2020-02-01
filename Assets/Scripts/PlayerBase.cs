using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{

    public float moveSpeed = 5f;
    public bool facingRight;
    private bool grndCheck;
    private bool inAirCheck;
    public float jumpHeight;
    public LayerMask grndLayer;
    public Transform grndCheckTransform;
    private Rigidbody2D rb;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Walk();
        Jump();
        FlipSprite();
        CheckGrounded();
    }

    private void CheckGrounded()
    {
        grndCheck = Physics2D.OverlapCircle(grndCheckTransform.position, 0.05f, grndLayer);
    }

    private void Walk()
    {
        float moveDir = Input.GetAxisRaw("Horizontal");
        Vector2 moveVect = new Vector2(moveDir * moveSpeed, rb.velocity.y);
        rb.velocity = moveVect;

        if (Mathf.Abs(rb.velocity.x) > 0.2f)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && grndCheck)
        {
            Vector2 jumpVelVect = new Vector2(0f, jumpHeight);
            rb.velocity += jumpVelVect;
        }

        if (!grndCheck)
        {
            anim.SetBool("isInAir", true);
        }
        else
        {
            anim.SetBool("isInAir", false);
        }
    }

    private void FlipSprite()
    {
        bool hasSpeed = Mathf.Abs(rb.velocity.x) > 0;
        facingRight = transform.localScale.x > 0;
        if (hasSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1f);
        }
    }
}
