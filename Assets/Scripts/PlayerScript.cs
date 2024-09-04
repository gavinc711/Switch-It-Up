using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private LayerMask layer;
    [SerializeField] private GameObject redPlatforms;
    [SerializeField] private GameObject bluePlatforms;
    private PlayerInput input;
    public Rigidbody2D rbody;
    public BoxCollider2D collider;
    public int speed = 5;
    public int jumpHeight = 20;

    void Awake()
    {
        input = new PlayerInput();
        rbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        redPlatforms.SetActive(false);
    }

    void Update()
    {
        move();

        if (input.Control.Jump.triggered && IsGrounded())
        {
            jump();
            stageChange();
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
        RaycastHit2D ray = Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.down, .1f, layer);
        return ray.collider != null;
    }

    public void stageChange()
    {
        if (redPlatforms.activeSelf)
        {
            redPlatforms.SetActive(false);
            bluePlatforms.SetActive(true);
        }
        else
        {
            redPlatforms.SetActive(true);
            bluePlatforms.SetActive(false);
        }
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