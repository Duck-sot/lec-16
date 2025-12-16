using Unity.Mathematics;
using UnityEngine;

public class Shootin : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos; 
    private bool canFier = true;
    public GameObject  BulletS; 
    public GameObject  BulletP;
    public GameObject  BulletShot;
    public GameObject  BulletA;
    public Transform bulletTransform;
    private float timer; 
    private float delay = 0.3f;
    private int weponeDex = 1; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCam = GameObject.FindAnyObjectByType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 Rotation = mousePos - transform.position; 
        float rotZ =  Mathf.Atan2(Rotation.y, Rotation.x)*Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,rotZ);

        if (!canFier)
        {
            timer+= Time.deltaTime;
            if (timer > delay)
            {
                canFier = true;
                timer = 0f; 
            }
        }
        WeponeSelect();
        Shoot();
        
    }
    public void WeponeSelect()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            weponeDex = 1;
            delay = 0.3f; 
            canFier = true;
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            weponeDex = 2;
            delay = 1.5f; 
            canFier = true;
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            weponeDex = 3;
            delay = 1.5f; 
            canFier = true;
        }
        else if (Input.GetKey(KeyCode.Alpha4))
        {
            weponeDex = 4;
            delay = 1.5f; 
            canFier = true;
        }
    }
    public void Shoot()
    {
        if (Input.GetMouseButton(0)&& canFier && weponeDex == 1)
        {
            canFier = false;
            Instantiate(BulletP, bulletTransform.position, quaternion.identity);
        }
        else if (Input.GetMouseButton(0)&& canFier && weponeDex == 2)
        {
            canFier = false;
            Instantiate(BulletS, bulletTransform.position, quaternion.identity);
        }
        else if (Input.GetMouseButton(0)&& canFier && weponeDex == 3)
        {
            canFier = false;
            Instantiate(BulletShot, bulletTransform.position, quaternion.identity);
        }
        else if (Input.GetMouseButton(0)&& canFier && weponeDex == 4)
        {
            canFier = false;
            Instantiate(BulletA, bulletTransform.position, quaternion.identity);
        }
    }
}
