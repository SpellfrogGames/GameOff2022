using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public static Player instance;
    Vector2 moveDirection;

    [Header("References")]
    public Rigidbody2D rb;

    [Space]
    [Header("Movement Stats")]
    public float baseMoveSpeed = 10.0f;
    public float moveSpeedModifier = 0.0f;
    public float moveSpeed;

    [Space]
    [Header("Leveling")]
    public int playerExp;
    public int playerLevel;
    public int[] levels;

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
    }

    void ProcessInput()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveHorizontal, moveVertical);
        moveDirection.Normalize();
    }

    void Move()
    {
        moveSpeed = baseMoveSpeed + moveSpeedModifier;
        rb.velocity = moveDirection * moveSpeed;
    }

    public void ExperienceCheck()
    {
        for(int i = playerLevel; i<levels.Length; i++)
        {
            if(playerExp == levels[i])
            {
                LevelUp();
            }
        }
    }

    void LevelUp()
    {
        playerLevel++;
        Debug.Log("Congrats! You've reached level: " + playerLevel);
    }
}
