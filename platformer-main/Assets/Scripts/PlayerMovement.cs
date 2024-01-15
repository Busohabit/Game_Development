using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance { get; set; }

    Rigidbody rb;
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] float knockbackForce = 10f;
    [SerializeField] float knockbackDuration = 0.5f;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    private PlayerControls controls;

    private InputAction playerMovement;

    private float knockbackTime = 0f;

    //for animations
    Animator animator;


    private void Awake()
    {
        Instance = this;
        controls = new PlayerControls();
        controls.Enable();
        playerMovement = controls.Player.Move;
        controls.Player.Jump.performed += ctx => Jump();
        animator = GetComponent<Animator>();
    }

    private void OnDestroy()
    {
        controls.Disable();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator.SetFloat("Vertical", 0f);

    }

    void Update()
    {
        if (!GameManager.Instance.gameStarted) return;

        if (knockbackTime <= 0f)
        {
            float horizontal = playerMovement.ReadValue<Vector2>().x;
            float vertical = playerMovement.ReadValue<Vector2>().y;

            //update animator parameters
            animator.SetFloat("Horizontal", horizontal);
            animator.SetFloat("Vertical", vertical);
            animator.SetBool("IsJumping", !IsGrounded());



            rb.velocity = new Vector3(horizontal * movementSpeed, rb.velocity.y, vertical * movementSpeed);

            if (IsGrounded() && controls.Player.Jump.triggered)
            {
                Jump();
            }
        }
        else
        {
            knockbackTime -= Time.deltaTime;
        }
    }

    void Jump()
    {
        if (IsGrounded())
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            animator.SetBool("IsJumping", true);
        }
    }

    public void Knockback(Vector3 direction)
    {
        rb.velocity = Vector3.zero;
        rb.AddForce(direction * knockbackForce, ForceMode.Impulse);
        knockbackTime = knockbackDuration;
    }

    //destroys enemy when jumped on
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Head"))
        {
            Destroy(collision.transform.parent.gameObject);
            Jump();
        }

        else if (collision.gameObject.CompareTag("Ground")) 
        {
            animator.SetBool("IsJumping", false);
        }

    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, 0.1f, ground);
    }
}
