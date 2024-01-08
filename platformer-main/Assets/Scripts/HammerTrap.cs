using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerTrap : MonoBehaviour
{
    public float attackTime;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        // Invoke the Attack method every attackTime seconds, starting after 0 seconds
        InvokeRepeating(nameof(Attack), 0f, attackTime);
    }


    void Attack()
    {
        // Check if the animator is not null before triggering the animation
        if (animator != null)
        {
            // Trigger the "attack" animation
            animator.SetTrigger("Attack");
        }
        else
        {
            Debug.LogError("Animator component not found on the GameObject.");
        }
    }
}
