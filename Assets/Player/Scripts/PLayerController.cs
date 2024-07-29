using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PLayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float HorizontalMove = 0f;
    private bool FacingRight = true;

    [Header("Player Movement Settings")]
    [Range(0, 10f)] public float Speed = 1f;
    [Range(0, 15f)] public float JumpForce = 8f;

    [Header("Player Animation Settings")]
    public Animator Animator;

    [Space]
    [Header("Ground Checer Settings")]
    public bool IsGrounded = false;
    [Range(-5f, 5f)] public float CheckGroundOffsetY = -1.8f;
    [Range(0, 5f)] public float CheckGroundRadius = 0.3f;



    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        PlayerMover();
    }

    private void FixedUpdate()
    {
        Vector2 targetVelocity = new Vector2(HorizontalMove * 10f, _rb.velocity.y);
        _rb.velocity = targetVelocity;
    }

    private void Flip()
    {
        FacingRight = !FacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void FlipSprite()
    {
        if (HorizontalMove < 0 && FacingRight)
            Flip();
        else if (HorizontalMove > 0 && !FacingRight)
            Flip();
    }

    private void TryJump()
    {
        CheckGround();

        if (IsGrounded == false)
            Animator.SetBool("Jumping", true);
        else
            Animator.SetBool("Jumping", false);

        if (IsGrounded && Input.GetKeyDown(KeyCode.Space))        
            _rb.AddForce(transform.up * JumpForce, ForceMode2D.Impulse);        
    }

    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll
            (new Vector2(transform.position.x, transform.position.y + CheckGroundOffsetY), CheckGroundRadius);

        if (colliders.Length > 0)
            IsGrounded = true;
        else
            IsGrounded = false;
    }

    private void PlayerMover()
    {
        TryJump();
        FlipSprite();
        Animator.SetFloat("HorizontalMove", Mathf.Abs(HorizontalMove));// Abs всегда получаем положительнрое число
        HorizontalMove = Input.GetAxisRaw("Horizontal") * Speed;
    }
}
