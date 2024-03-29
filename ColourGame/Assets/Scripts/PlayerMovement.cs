using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    private float dirx = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    [SerializeField] private LayerMask jumpableGround;
    private enum MovementState { idle, Runnning, jumping, falling }

    [SerializeField] private AudioSource jumpSoundEffect;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirx = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirx * moveSpeed, rb.velocity.y);

        if (Input.GetKey("space")&& IsGrounded() )
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        UpdateAnimation();
    }

    private void UpdateAnimation() {
        MovementState state;


        if (dirx > 0f)
        {
            state = MovementState.Runnning;
            sprite.flipX = false;
        }
        else if (dirx < 0f)
        {
            state = MovementState.Runnning;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f) {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f) {
            state = MovementState.falling;
        }
        anim.SetInteger("state", (int)state);
    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
