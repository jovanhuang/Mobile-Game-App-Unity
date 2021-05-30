using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

/// PlayerMovement class controls the in game player behaviour
public class PlayerMovement : MonoBehaviour
{
    /// @param speed = 5f controls the speed of the player
    public float speed = 5f;
    /// @param jumpSpeed = 5f controls the jump of the player
    public float jumpSpeed = 5f;
    /// @param movement = 0f controls the player animation
    private float movement = 0f;
    /// @param rigidBody is the gameObject "Player"
    private Rigidbody2D rigidBody;
    /// @param groundCheckPoint a the point of contact between ground and player
    public Transform groundCheckPoint;
    /// @param groundCheckRadius is the radius of contact enabled between ground and player
    public float groundCheckRadius;
    /// @param groundLayer to set which game object is ground
    public LayerMask groundLayer;
    /// @param isTouchingGround is to check player is on ground or not on ground
    private bool isTouchingGround;
    /// @param anim controls the animation of the player
    private Animator anim;
    /// @param collision invokes Unity function to check for collision between game objects
    private Collision2D collision;
    /// @param whatSceneWhatQuestion calls WhatSceneWhatQuestion class
    public WhatSceneWhatQuestion whatSceneWhatQuestion;

    /// Start is called before the first frame update
    ///
    /// Start function here initialises player components and animation
    ///
    /// Start function here also checks for value of sceneNumber from WhatSceneWhatQuestion class
    ///
    /// Start function here also gets players previous vectors or deletes saved vectors depending on sceneNumber value
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        whatSceneWhatQuestion = GameObject.Find("Variable").GetComponent<WhatSceneWhatQuestion>();

        // get players vectors from before transition
        if (whatSceneWhatQuestion.sceneNumber >= 1 && whatSceneWhatQuestion.sceneNumber <= 4) {
            rigidBody.transform.position = new Vector2(PlayerPrefs.GetFloat("SavedXPosition") + (float)3, (float)-2.2);
        }
        // deletes saved data
        else {
            PlayerPrefs.DeleteKey("SavedXPosition");
        }
    }

    /// Update is called once per frame
    /// Update function here manages the players controls and animations
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
