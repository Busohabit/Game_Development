using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerInput playerInput;
    InputAction inputAction;
    [SerializeField] float speed = 5.0f;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        inputAction = playerInput.actions.FindAction("Move");
        
    }

    // Update is called once per frame
    void Update()
    {
        onMove();
    }


    void onMove(){
        Vector2 direction = inputAction.ReadValue<Vector2>();
        transform.position += new Vector3(direction.x, 0, direction.y) * speed * Time.deltaTime;

    }


}
