using UnityEngine;
using System.Collections;
public class playerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rb;
    public float forwardForce = 800f;
    public float rotateForce = 60f;
    // Update is called once per frame
    void FixedUpdate()
    {
        // rb.AddForce(0,0,forwardForce*Time.deltaTime);// force along z axis
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(0,forwardForce*Time.deltaTime,0);// force to make player jump
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            rb.transform.Rotate(Vector3.up * horizontalInput * rotateForce * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            rb.transform.Rotate(Vector3.up * horizontalInput * rotateForce * Time.deltaTime);            
        }
        if(transform.rotation.eulerAngles.y < 180f)
        {
            if (Input.GetKey("w"))
            {
                rb.AddForce(0,0,forwardForce*Time.deltaTime);// force along Frontside 
            }
            if (Input.GetKey("s"))
            {
                rb.AddForce(0,0,-forwardForce*Time.deltaTime);// force along Backside
            }
            if (Input.GetKey("a"))
            {
                rb.AddForce(forwardForce*Time.deltaTime,0,0);// force along Right side
            }
            if (Input.GetKey("d"))
            {
                rb.AddForce(-forwardForce*Time.deltaTime,0,0);// force along Left Side
            }
        }
        if(transform.rotation.eulerAngles.y > 180f)
        {
            if (Input.GetKey("w"))
            {
                rb.AddForce(0,0,-forwardForce*Time.deltaTime);// force along Frontside 
            }
            if (Input.GetKey("s"))
            {
                rb.AddForce(0,0,forwardForce*Time.deltaTime);// force along Backside
            }
            if (Input.GetKey("a"))
            {
                rb.AddForce(-forwardForce*Time.deltaTime,0,0);// force along Right side
            }
            if (Input.GetKey("d"))
            {
                rb.AddForce(forwardForce*Time.deltaTime,0,0);// force along Left Side
            }
        }
    }
}
