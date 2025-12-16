using UnityEngine;

public class EnemyBoss : MonoBehaviour
{
    public float speed = 10f;
    private int direction = 1;
    private Rigidbody2D rb;
    public GameObject projectilePrefab;
    public Transform shootPoint;
    public float shootDelay = 1f;
    public float bulletSpeed = 12f;
    private float shootTimer = 0f;
    private bool playerInRange = false;
    private Transform playerTransform;
    private int hp = 500;

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
    void Update()
    {
        if (playerInRange && playerTransform != null)
        {
            shootTimer += Time.deltaTime;
            if (shootTimer >= shootDelay)
            {
                ShootAt(playerTransform.position);
                shootTimer = 0f;
            }
        }
    }
    void ShootAt(Vector2 targetPos)
    {
        if (projectilePrefab == null || shootPoint == null) return;

        Vector2 dir = (targetPos - (Vector2)shootPoint.position).normalized;

        GameObject bullet = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
        Rigidbody2D bRb = bullet.GetComponent<Rigidbody2D>();
        if (bRb != null)
        {
            bRb.linearVelocity = dir * bulletSpeed;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            playerTransform = other.transform;
            shootTimer = shootDelay;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            playerTransform = null;
            shootTimer = 0f;
        }
    }
}