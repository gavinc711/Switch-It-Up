using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    //Gavin's variables
    [SerializeField] private LayerMask platformLayer; //allows ground detection
	[SerializeField] private LayerMask deathLayer; //allows detection with death tiles
    [SerializeField] private GameObject redPlatforms;
    [SerializeField] private GameObject bluePlatforms;
	[SerializeField] private Transform respawn;
    [SerializeField] private GameObject pauseMenu;
    private GameObject player;
    private PlayerInput input;
    public Rigidbody2D rbody;
    public CapsuleCollider2D collider;
    public int speed = 5;
    public int jumpHeight = 20;

    //All of Dante's variables
    private Animator animator;
    private bool grounded = true;
    private float horizontal;
    private bool isFacingRight = true;
    private bool isDead;

    //sets everything as game starts up
    void Awake()
    {
        input = new PlayerInput(); //initializes input
        rbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<CapsuleCollider2D>();
        redPlatforms.SetActive(false); //turns red platforms off
		player = this.gameObject; //sets player to the object attatched to this script
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator component is missing from the GameObject.");
        }
    }

    void Update()
    {
        //Check for grounded for anims
        grounded = IsGrounded();
        animator.SetBool("Grounded", grounded); // Set the Animator's Grounded parameter
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(horizontalMovement));

        move();
        horizontal = Input.GetAxisRaw("Horizontal");
        Flip();
        
        //Check if jump is pressed and player is on the ground
        if (input.Control.Jump.triggered && IsGrounded())
        {
            //Prevent these actions from happening if paused
            if (!pauseMenu.activeSelf)
            {
                jump();
                stageChange();
            }
        }
		
        //Check if player is touching death tile with respective layer
		if (Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.down, .1f, deathLayer))
		{
            if(isDead == false)
			    death();
		}

        //Pauses and unpauses game
        if (input.Control.Pause.triggered)
        {
            gamePause();
        }

        //If any quit button is pressed, for debug purposes
        if (input.Control.Quit.triggered)
		{
			Application.Quit();
			Application.Quit();
		}
    }
    private void move()
    {
        var horizontal = input.Control.Movement.ReadValue<Vector2>();
        
        //prevent movement if paused
        if (!pauseMenu.activeSelf)
            transform.Translate(horizontal * speed * Time.deltaTime);
    }

    private void jump()
    {
        rbody.velocity += Vector2.up * jumpHeight;
    }

    public void gamePause()
    {
        if (!pauseMenu.activeSelf)
        {
            pauseMenu.SetActive(true);
        }
        else
            pauseMenu.SetActive(false);
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
        // Trigger the death animation
        animator.SetBool("IsDead", true);
        isDead = true;

        // Disable player controls to prevent movement during death
        input.Disable();

        // Start respawn process after a short delay for the death animation to finish
        StartCoroutine(RespawnAfterDelay(2f));
        
    }

    private IEnumerator RespawnAfterDelay(float delay)
    {
        // Wait for the death animation to finish
        yield return new WaitForSeconds(delay);
        // Re-enable player controls
        input.Enable();

        // Move player to the respawn point immediately
        player.transform.position = respawn.position;

        // Reset Rigidbody2D velocity to prevent floating or unintended motion
        rbody.velocity = Vector2.zero;

        // Slightly delay before re-enabling input to ensure physics settles
        yield return new WaitForEndOfFrame();

        // Re-enable gravity after ensuring the player is grounded
        rbody.gravityScale = 5f;

        // Reset the death state in the Animator
        animator.SetBool("IsDead", false);
        isDead = false;

 
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

    //This allows me to only use 1 animation clip, and just change the X scale to -1 to flip the character.  Works in 2D
    private void Flip()
    {
        if (isDead == false)
        {
            if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
            {
                isFacingRight = !isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }
        }
    }
}