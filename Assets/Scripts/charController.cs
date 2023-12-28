using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charController : MonoBehaviour
{
    public float speed = 0.0f;
    Rigidbody2D _rb2D;
    Animator _animator;

    void Start()
    {
        
        _rb2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        _animator.SetFloat("speed", speed);
        _rb2D.velocity = new Vector2(speed, .0f);

        if (Input.GetKey(KeyCode.D))
        { speed = 1.0f; }

        else
        { speed = 0.0f; }
    }
}