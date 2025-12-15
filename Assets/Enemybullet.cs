using UnityEngine;

public class Enemybullet : MonoBehaviour
{
    public float lifeTime = 5f;
    public int damage = 1;
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

        if (other.CompareTag("ground"))
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
