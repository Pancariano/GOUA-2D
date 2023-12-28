using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class charController2 : MonoBehaviour
{
    public float jumpForce;
    public float speed;
    private float moveDirection;
    
    private bool _isJumping;
    private bool _isGrounded = true;
    private bool _isMoving;
    private Rigidbody2D _rb2D;
    private SpriteRenderer _spriteRenderer;
    private Animator _anim;

    private void Awake()
    {
        _anim = GetComponent<Animator>();       
    }

    private void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        _isMoving = _rb2D.velocity != Vector2.zero ? true : false;

        _rb2D.velocity = new Vector2(speed * moveDirection, _rb2D.velocity.y);
        if (_isJumping)
        {
            _rb2D.velocity = new Vector2(_rb2D.velocity.x, jumpForce);
            _isJumping = false;

        }
    }

    private void Update()
    {
        if (_isGrounded && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))  
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                moveDirection = -1f;
                _spriteRenderer.flipX = true;
                _anim.SetFloat("speed", speed);
            }

            else if (Input.GetKeyDown(KeyCode.D))
            {
                moveDirection = 1f;
                _spriteRenderer.flipX = false;
                _anim.SetFloat("speed", speed);
            }   
        }

        else if (_isGrounded)
        {
            moveDirection = 0f;
            _anim.SetFloat("speed", 0f);
        }
        
        if(_isGrounded && Input.GetKey(KeyCode.W))
        {
            _isJumping = true;
            _isGrounded = false;
            _anim.SetTrigger("jump");
            _anim.SetBool("grounded", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("zemin"))
        {
            _anim.SetBool("grounded", true);
            _isGrounded = true;
        }
    }
}