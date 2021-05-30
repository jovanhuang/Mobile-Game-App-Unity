using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class playerMovementLvl4 : MonoBehaviour
{
    public float speed = 5f;
    public float jumpSpeed = 5f;
    private float movement = 0f;
    private Rigidbody2D rigidBody;
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;
    private Animator anim;
    private Collision2D collision;
    private float xPos;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);
        movement = CrossPlatformInputManager.GetAxis("Horizontal");
        if (movement > 0f) {
            rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
            transform.localScale = new Vector2(2.5f, 2.5f);
        }
        else if (movement < 0f) {
            rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
            transform.localScale = new Vector2(-2.5f, 2.5f);
        }
        else {
             rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
        }

        if (CrossPlatformInputManager.GetButtonDown("Jump") && isTouchingGround) {
             rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
        }

        anim.SetFloat("Speed", Mathf.Abs(rigidBody.velocity.x));
        anim.SetBool("onGround", isTouchingGround);
    }
}
