using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayer; //allows ground detection
	[SerializeField] private LayerMask deathLayer; //allows detection with death tiles
    [SerializeField] private GameObject redPlatforms;
    [SerializeField] private GameObject bluePlatforms;
	[SerializeField] private Transform respawn; 
	private GameObject player;
    private PlayerInput input;
    public Rigidbody2D rbody;
    public BoxCollider2D collider;
    public int speed = 5;
    public int jumpHeight = 20;

    //sets everything as game starts up
    void Awake()
    {
        input = new PlayerInput(); //initializes input
        rbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        redPlatforms.SetActive(false); //turns red platforms off
		player = this.gameObject; //sets player to the object attatched to this script
    }

    void Update()
    {
        move();

        //Check if jump is pressed and player is on the ground
        if (input.Control.Jump.triggered && IsGrounded())
        {
            jump();
            stageChange();
        }
		
        //Check if player is touching death tile with respective layer
		if (Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.down, .1f, deathLayer))
		{
			death();
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

    //Checks is player's touching any ground tile with the ground layer
    public bool IsGrounded()
    {
        RaycastHit2D ray = Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.down, .1f, platformLayer);
        return ray.collider != null;
    }

    //Switches environment with every jump
    public void stageChange()
    {
        //If red platforms are active, turn them off and turn on blue platforms
        if (redPlatforms.activeSelf)
        {
            redPlatforms.SetActive(false);
            bluePlatforms.SetActive(true);
        }
        //opposite of above
        else
        {
            redPlatforms.SetActive(true);
            bluePlatforms.SetActive(false);
        }
    }
	
	public void death()
	{
		player.transform.position = respawn.position; //player taken to respawn point
	}

    //Enables input on startup
    private void OnEnable()
    {
        input.Enable();
    }

    //Stops input on close
    private void OnDisable()
    {
        input.Disable();
    }
}