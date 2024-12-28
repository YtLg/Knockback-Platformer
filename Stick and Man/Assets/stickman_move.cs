using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stickman_move : MonoBehaviour
{
    public Rigidbody2D playerBody;
    public BoxCollider2D playerCollider;
    public SpriteRenderer playerSprite;
    public float playerMovespeed;
    Animator animator;

    public FreezeController freeze;

    private int isGrounded = 0;
    private bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!freeze.isFrozen)
        {

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            playerBody.velocity = new Vector2(1.5f * playerMovespeed, playerBody.velocity.y);
            playerSprite.flipX = false;
        }

        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            playerBody.velocity = new Vector2(-1.5f * playerMovespeed, playerBody.velocity.y);
            playerSprite.flipX = true;
        }

        else
        {
            if (isGrounded > 0 && isJumping == false)
            {
                Debug.Log("Grounded so halting velocity");
                    Debug.Log(isGrounded);
                playerBody.velocity = Vector2.zero;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded > 0)
        {
            isJumping = true;
            Debug.Log("jumping");
            playerBody.velocity = new Vector2(playerBody.velocity.x, 3f * playerMovespeed);
            animator.SetBool("jumping", true);
        }

        animator.SetFloat("movementSpeed", Mathf.Abs(playerBody.velocity.x));

            if (Input.GetKeyDown(KeyCode.T) && SceneManager.GetActiveScene().buildIndex != 5)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }


        }

        if (freeze.isFrozen)
        {
            playerBody.velocity = new Vector2(0, 0);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isJumping = false;
        isGrounded += 1;
        animator.SetBool("jumping", false);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded -= 1;
    }
}
