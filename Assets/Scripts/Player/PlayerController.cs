using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rb;

    [SerializeField] private float JumpForce = 5f;
    [SerializeField] private float MoveForce = 5f;
    private bool facingRight = true;

    [SerializeField] private LayerMask GroundLayer;
    [SerializeField] private Collider2D GroundCheckCollider;

    private enum FlightStatus
    {
        Grounded,
        Ballistic,
        Jump
    };

    private FlightStatus _flightStatus = FlightStatus.Ballistic;

    // Animator Hashes
    private static readonly int IsJumping = Animator.StringToHash("isJumping");
    private static readonly int XVelocity = Animator.StringToHash("xVelocity");
    private static readonly int YVelocity = Animator.StringToHash("yVelocity");

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();

        if (!GroundCheckCollider)
            GroundCheckCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown("space") && _flightStatus == FlightStatus.Grounded)
        {
            _flightStatus = FlightStatus.Jump;

            // _rb.velocity = new Vector2(_rb.velocity.x, JumpForce);
            _animator.SetBool(IsJumping, true);
        }

        Move(horizontalInput);
    }

    private void Move(float horizontalInput)
    {
        switch (_flightStatus)
        {
            case FlightStatus.Grounded or FlightStatus.Ballistic:
            {
                _rb.velocity = new Vector2(horizontalInput * MoveForce, _rb.velocity.y);

                _animator.SetFloat(XVelocity, Mathf.Abs(_rb.velocity.x));
                _animator.SetFloat(YVelocity, _rb.velocity.y);

                if (horizontalInput > 0 && !facingRight)
                {
                    Flip();
                }
                else if (horizontalInput < 0 && facingRight)
                {
                    Flip();
                }

                break;
            }
            case FlightStatus.Jump:
                // Double jump.
                _flightStatus = FlightStatus.Ballistic;
                _rb.AddForce(new Vector2(0f, JumpForce));
                break;
        }
    }
    
    private void FixedUpdate()
    {
        if (GroundCheckCollider.IsTouchingLayers(GroundLayer))
        {
            Debug.Log("Touching ground..");
            _flightStatus = FlightStatus.Grounded;
            _animator.SetBool(IsJumping, false);
        }
        else
        {
            _animator.SetBool(IsJumping, true);
        }
    }

    // private void OnTriggerEnter2D(Collider2D other)
    // {
        // _flightStatus = FlightStatus.Grounded;
        // _animator.SetBool(IsJumping, false);
    // }


    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        var theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}