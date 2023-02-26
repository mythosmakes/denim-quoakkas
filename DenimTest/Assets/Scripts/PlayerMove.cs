using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMove : MonoBehaviour
{
    public EnemyAI enemy;

    [Header("Movement")]
    public float moveSpeed;
    public float walkSpeed;
    public float sprintSpeed;

    public float groundDrag;

    [Header("Jumping")]
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyTojump;

    [Header("Crouching")]
    public float crouchSpeed;
    public float crouchYScale;
    private float startYScale;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode sprintKey = KeyCode.LeftShift;
    public KeyCode crouchKey = KeyCode.LeftControl;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    [Header("Health")]
    public int maxHealth;
    public int currentHealth;    
    public float timeBetweenDamage;
    public TextMeshProUGUI healthDisplay;

    [Header("Screens")]
    public GameObject damageScreen;
    public GameObject deathText;
    public GameObject winScreen;

    [Header("Interact")]
    public int cumulate;
    public TextMeshProUGUI scoreText;
    public GameObject finalSwitch;

    [Header("Motion")]
    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    public MovementState state;

    public enum MovementState
    {
        walking,
        sprinting,
        crouching,
        air
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        readyTojump = true;
        startYScale = transform.localScale.y;

        currentHealth = maxHealth;
        damageScreen.SetActive(false);
        deathText.SetActive(false);
        winScreen.SetActive(false);
        finalSwitch.SetActive(false);

        scoreText.text = "Score: " + 0;
        healthDisplay.text = "Health: " + maxHealth;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void Update()
    {
        //ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        //drag
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;

        MyInput();
        SpeedControl();
        StateHandler();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(jumpKey) && readyTojump && grounded)
        {
            readyTojump = false;

            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
        }

        //crouch
        if (Input.GetKeyDown(crouchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
            rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
        }

        //stand
        if (Input.GetKeyUp(crouchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);
        }
    }

    void StateHandler()
    {
        // crouch
        if (Input.GetKey(crouchKey))
        {
            state = MovementState.crouching;
            moveSpeed = crouchSpeed;
        }

        //sprint
        if (grounded && Input.GetKey(sprintKey) && moveSpeed != crouchSpeed)
        {
            state = MovementState.sprinting;
            moveSpeed = sprintSpeed;
        }

        //walk
        else if (grounded)
        {
            state = MovementState.walking;
            moveSpeed = walkSpeed;
        }

        //air
        else
        {
            state = MovementState.air;
        }
    }

    void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        else if (!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
    }

    void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    public void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    void ResetJump()
    {
        readyTojump = true;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        healthDisplay.text = "Health: " + currentHealth;

        Invoke(nameof(DamageScreen), timeBetweenDamage);

        if (currentHealth <= 0)
        {
            Debug.Log("ded");
            damageScreen.SetActive(true);
            deathText.SetActive(true);
            Time.timeScale = 0f;            
        }
    }

    public void DamageScreen()
    {
        damageScreen.SetActive(true);

        Invoke(nameof(UndoDamage), 0.5f);
    }

    public void UndoDamage()
    {
        damageScreen.SetActive(false);
    }

    public void Plates()
    {
        cumulate = cumulate + 1;
        scoreText.text = "Score: " + cumulate;

        if (cumulate == 3)
        {
            finalSwitch.SetActive(true);
        }

        if (cumulate == 4)
        {
            winScreen.SetActive(true);
            rb.constraints = RigidbodyConstraints.FreezePosition;
        }
    }    
}