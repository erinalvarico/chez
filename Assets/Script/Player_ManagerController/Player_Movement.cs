using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D RB;

    private Vector2 moveDirection;

    // Update is called once per frame
    void Update()
    {
        // Processing Inputs
        ProcessInputs();
    }

    private void FixedUpdate()
    {
        // Physics Calculations
        Move();
    }

  void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    private void Move()
    {
        RB.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
}
