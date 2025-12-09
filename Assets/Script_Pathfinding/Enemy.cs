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