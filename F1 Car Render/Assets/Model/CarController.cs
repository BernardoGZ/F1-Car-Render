using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    Rigidbody rb;
    float horizontal;
    float vertical;
    private float speed = 5.0f;
    Vector3 m_EulerAngleVelocity;
    Vector3 m_EulerAngleVelocity2;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        m_EulerAngleVelocity = new Vector3(0, 100, 0);
        m_EulerAngleVelocity2 = new Vector3(0, -100, 0);
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    private void FixedUpdate() 
    {
         Controller();
    }

    void Controller() {
        Vector3 position = rb.position;
        Quaternion rotation = rb.rotation;
        Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.fixedDeltaTime);
        Quaternion deltaRotation2 = Quaternion.Euler(m_EulerAngleVelocity2 * Time.fixedDeltaTime);
        
        // Primary Movement
        // if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)))
        // {            
        //     position.z = position.z - horizontal * Time.fixedDeltaTime * speed;          
        // }

        if ((Input.GetKey(KeyCode.RightArrow)))
        {            
            rb.MoveRotation(rb.rotation * deltaRotation);
        }

        if ((Input.GetKey(KeyCode.LeftArrow)))
        {            
            rb.MoveRotation(rb.rotation * deltaRotation2);
        }

        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)))
        {
        
            position.x = position.x + vertical * Time.fixedDeltaTime * speed;       
            
        }
        
        if (Input.GetKey(KeyCode.Space)) {
           
        }

        rb.MovePosition(position);    
        // rb.MoveRotation(rotation); 
        
    }
}
