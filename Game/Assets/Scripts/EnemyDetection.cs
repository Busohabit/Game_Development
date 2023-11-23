using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public float detectionRange = 10f;
    public float detectionAngle = 45f; // Adjust the angle based on your requirements
    public float speed = 3f;
    private Transform player;


    void Update()
    {
        DetectPlayer();
    }

    void DetectPlayer()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, detectionRange))
        {
            if (hit.collider.CompareTag("Player"))
            {
                // Check if the player is within the detection angle
                Vector3 directionToPlayer = hit.collider.transform.position - transform.position;
                float angle = Vector3.Angle(transform.forward, directionToPlayer);

                if (angle < detectionAngle * 0.5f)
                {
                    // Player detected within the specified angle, start chasing
                    player = hit.collider.transform;
                    ChasePlayer();
                }
            }
        }
    }

    void ChasePlayer()
    {
        // Move towards the player
        transform.LookAt(player);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}