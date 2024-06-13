    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anima;
    private BoxCollider2D coll;
    private bool doubleJump;

    private float dirX = 0f;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 7f;

    private enum MovementState { idle, running, jumping, falling, doubleJump};
    //private MovementState state = MovementState.idle;
    [SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anima = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        

        UpdateAnimationState();
        if (Input.GetButtonDown("Jump"))
        {
            jumpSoundEffect.Play();
            if (IsGrounded() || doubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);

                doubleJump = !doubleJump;
            }
        }
    }
    private void UpdateAnimationState()
    {
        MovementState state;
        if (dirX > 0f || dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
            if (dirX < 0f)
            {
                state = MovementState.running;
                sprite.flipX = true;
            }
        }
        else
        {
            state = MovementState.idle;
        }
        if(rb.velocity.y > .1f)
        {
            state = MovementState.jumping;   
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anima.SetInteger("state", (int)state);
    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
