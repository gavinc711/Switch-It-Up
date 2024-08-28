using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    private PlayerInput input;
    public Rigidbody2D rbody;
    public BoxCollider2D collider;
    public int speed = 5;
    public int jumpHeight = 5;
    public bool isGrounded;

    void Awake()
    {
        input = new PlayerInput();
        rbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        move();

        if (input.Control.Jump.triggered && IsGrounded())
        {
            jump();
        }
    }
    private void move()
    {
        var horizontal = input.Control.Movement.ReadValue<Vector2>();
        horizontal.y = 0;
        transform.Translate(horizontal * speed * Time.deltaTime);
    }

    private void jump()
    {
        rbody.velocity += Vector2.up * jumpHeight;
    }

    public bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }
}