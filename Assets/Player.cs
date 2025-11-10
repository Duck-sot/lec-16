using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void Move()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(10f, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(10f, 0, 0);
        }
    }
}
