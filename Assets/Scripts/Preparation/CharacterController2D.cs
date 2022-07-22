using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Preparation
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class CharacterController2D : MonoBehaviour
    {
        public float _jumpStrength = 7f;

        public float _movementSpeed = 3f;

        private Rigidbody2D _rb2d;

        private float _horizontalInput;

        private bool _isGrounded;

        private void Awake()
        {
            _rb2d = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            Move();
            Jump();
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                _isGrounded = true;
            }
        }

        private void OnCollisionExit2D(Collision2D other) {
            if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                _isGrounded = false;
            }
        }

        private void Move()
        {
            _horizontalInput = Input.GetAxisRaw("Horizontal");

            if (_horizontalInput != 0f)
            {
                var targetVelocity = _rb2d.velocity;
                targetVelocity.x = _horizontalInput * _movementSpeed;
                _rb2d.velocity = targetVelocity;
            }
            else
            {
                if (_isGrounded)
                {
                    _rb2d.velocity = new Vector2(0f, _rb2d.velocity.y);
                }
            }
        }

        private void Jump()
        {
            if (_isGrounded && Input.GetButtonDown("Jump"))
            {
                _rb2d.AddForce(Vector2.up * _jumpStrength, ForceMode2D.Impulse);
            }
        }
    }

}