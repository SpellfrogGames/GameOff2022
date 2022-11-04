using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

    [Header("References")]
    public Rigidbody2D rb;
    public Camera cam;

    [Space]
    [Header("Movement Stats")]
    public float baseMoveSpeed = 10.0f;
    public float moveSpeedModifier = 0.0f;
    public float moveSpeed;

    Vector2 movement;
    Vector2 mousePos;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        ProcessInput();
    }

    void FixedUpdate()
    {
        Move();
        Rotate();
    }

    void ProcessInput()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void Move()
    {
        moveSpeed = baseMoveSpeed + moveSpeedModifier;
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void Rotate()
    {
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        
        rb.rotation = angle;
    }
}
