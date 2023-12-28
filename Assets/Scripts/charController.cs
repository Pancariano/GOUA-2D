using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charController : MonoBehaviour
{
    public float speed = 0.0f;
    Rigidbody2D _rb2D;
    Animator _animator;
    Vector3 _charPosition;
    [SerializeField] private GameObject _camera;

    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _charPosition = transform.position;
    }

    void FixedUpdate()
    {
        //_rb2D.velocity = new Vector2(speed, .0f);
    }

    void Update()
    {
        _charPosition = new Vector2(_charPosition.x + (speed * Time.deltaTime), _charPosition.y);
        transform.position = _charPosition;
        _animator.SetFloat("speed", speed);
       
        if (Input.GetKey(KeyCode.D))
            speed = 1f;
        else if (Input.GetKey(KeyCode.A))
            speed = -1f;
        else
            speed = 0f;
    }

    void LateUpdate()
    {
        _camera.transform.position = new Vector3(_charPosition.x, _charPosition.y, (_charPosition.z - 1f));
    }
}