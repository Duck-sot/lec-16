using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    private int direction = 1;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(direction * speed, rb.linearVelocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        direction *= -1;
        FlipSprite();
    }

    void FlipSprite()
    {
        Vector3 s = transform.localScale;
        s.x *= -1;
        transform.localScale = s;
    }
}



































/*
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float walkSpeed = 1.0f;
    public float wallLeft = 0.0f;
    public float wallRight = 5.0f;

    float walkingDirection = 1.0f;

    void Update()
    {
        Vector2 walkAmount = new Vector2(walkingDirection * walkSpeed * Time.deltaTime, 0f);

        if (walkingDirection > 0f && transform.position.x >= wallRight)
        {
            transform.position = new Vector3(wallRight, transform.position.y, transform.position.z);
            walkingDirection = -1.0f;
            FlipSprite();
        }
        else if (walkingDirection < 0.0f && transform.position.x <= wallLeft - 0.01f)
        {
            transform.position = new Vector3(wallLeft, transform.position.y, transform.position.z);
            walkingDirection = 1.0f;
            FlipSprite();
        }

        transform.Translate(walkAmount, Space.World);
    }

    void FlipSprite()
    {
        Vector3 s = transform.localScale;
        s.x *= -1;
        transform.localScale = s;
    }
}
*/
















/*

using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float walkSpeed = 1.0f;      // Walkspeed
    public float wallLeft = 0.0f;       // Define wallLeft
    public float wallRight = 5.0f;      // Define wallRight
    float walkingDirection = 1.0f;
    Vector2 walkAmount;
    float originalX; // Original float value
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.originalX = this.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
          walkAmount.x = walkingDirection * walkSpeed * Time.deltaTime;
        if (walkingDirection > 0.0f && transform.position.x >= wallRight) {
            walkingDirection = -1.0f;
        } else if (walkingDirection < 0.0f && transform.position.x <= wallLeft) {
            walkingDirection = 1.0f;
        }
        transform.Translate(walkAmount);
    }
}
*/