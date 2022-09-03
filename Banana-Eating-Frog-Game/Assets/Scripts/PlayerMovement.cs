using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const float moveSpeed = 5f;
    private const float jumpForce = 7f;

    private float dirX = 0f;

    private Rigidbody2D rb2D;
    private BoxCollider2D collider;
    private SpriteRenderer sprite;
    private Animator animator;

    // Layer of jumpable terrain applied on the editor
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private AudioSource jumpSoundEffect;

    private enum MovementState { idle, running, jumping, falling }

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb2D.velocity = new Vector2(dirX * moveSpeed, rb2D.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSoundEffect.Play();
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);   
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (dirX != 0f)
        {
            state = MovementState.running;

            if (dirX > 0f)
                sprite.flipX = false;
            else
                sprite.flipX = true;
        }
        else
            state = MovementState.idle;

        if (rb2D.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        
        else if (rb2D.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        animator.SetInteger("state", (int)state);
    }

    // Solution to jumping on edges 
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
