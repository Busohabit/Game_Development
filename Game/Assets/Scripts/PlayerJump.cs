using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    Rigidbody rb;
    PlayerInput playerInput;
    InputAction inputAction;

    [SerializeField] float jumpForce = 50;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    bool isGrounded = false;

    public void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        inputAction = playerInput.actions.FindAction("Jump");
        rb = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        inputAction.performed += Jump;
    }

    void OnDisable()
    {
        inputAction.performed -= Jump;
    }

    void Jump(InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            isGrounded = false; // Player is no longer grounded after jumping
        }
    }

    void Update()
    {
        // Check if the player is grounded in each frame
        isGrounded = IsGrounded();
    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }
}
