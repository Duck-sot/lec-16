using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private bool grounded = true; 
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(+5*Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-5* Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            if(grounded == true)
            {
                transform.position += new Vector3(0, +100 * Time.deltaTime, 0);
                grounded = false; 
            }
        }
        
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "ground")
        {
            grounded = true; 
        }
        
    }
}
 