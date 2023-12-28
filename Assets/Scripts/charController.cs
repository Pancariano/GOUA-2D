using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charController : MonoBehaviour
{
    public float speed = 1.0f;
    Rigidbody2D _rb2D;
    Animator _animator;
    Vector3 _charPosition;
    [SerializeField] GameObject _camera;
    SpriteRenderer _spriteRenderer;

    void FixedUpdate()
    {
        //_rb2D.velocity = new Vector2(speed, .0f);
    }

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rb2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _charPosition = transform.position;
    }

    void Update()
    {
        _charPosition = new Vector3(_charPosition.x + (Input.GetAxis("Horizontal") * speed * Time.deltaTime), _charPosition.y);
        transform.position = _charPosition;

        if (Input.GetAxis("Horizontal") == 0f)
            _animator.SetFloat("speed", 0f);
        else 
            _animator.SetFloat("speed", 1.0f);

        if (Input.GetAxis("Horizontal") > 0.1f)
            _spriteRenderer.flipX = false;     
        else if (Input.GetAxis("Horizontal") < 0.1f)
            _spriteRenderer.flipX=true;
        
    }

    void LateUpdate()
    {
       // _camera.transform.position = new Vector3(_charPosition.x, _charPosition.y, (_charPosition.z - 1f));
    }
}