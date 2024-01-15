using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float moveSpeed = 5;
    public float leftPoint = -10f;
    public float rightPoint = 5f;
    public bool reverse = false;

    private int moveDir = 1;

    private void Start()
    {
        moveDir = (reverse) ? -1 : 1;
    }

    private void Update()
    {
        transform.Translate(Vector3.right * moveSpeed * moveDir * Time.deltaTime);

        if (transform.position.x >= rightPoint)
        {
            moveDir = -1;
        } 
        else if (transform.position.x <= leftPoint)
        {
            moveDir = 1;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.transform.SetParent(transform);
    }

    private void OnCollisionExit(Collision collision)
    {
        collision.gameObject.transform.SetParent(null);
    }

}
