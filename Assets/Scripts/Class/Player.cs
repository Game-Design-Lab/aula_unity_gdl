using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D _rb2d;

    public float _horizontalInput;

    public float _movementSpeed = 7f;

    public float _jumpingStrength = 3f;

    public float _shootingStrength = 3f;

    public bool _isGrounded;

    public Rigidbody2D _projectilePrefab;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            _isGrounded = false;
        }
    }

    private void Awake()
    {
       _rb2d = GetComponent<Rigidbody2D>(); 
    }

    private void Update()
    {
        Move();
        Jump();

        if (Input.GetButtonDown("Fire"))
        {
            var projectile = Instantiate(_projectilePrefab);
            projectile.AddForce(Vector2.right * _shootingStrength, ForceMode2D.Impulse);
            Destroy(projectile.gameObject, 1f);
        }
    }

    private void Move()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _rb2d.velocity = new Vector2(_horizontalInput * _movementSpeed, _rb2d.velocity.y);
    }

    private void Jump()
    {
        if (_isGrounded && Input.GetButtonDown("Jump"))
        {
            _rb2d.AddForce(new Vector2(0f, 1f) * _jumpingStrength, ForceMode2D.Impulse);
        }
    }
}
