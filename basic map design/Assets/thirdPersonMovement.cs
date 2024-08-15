using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdPersonMovement : MonoBehaviour
{
    public Transform cam;
    public CharacterController controller;
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");// since we don't want anykind of input smoothing. its value will be -1 if we press the 'a' key or left arrow key and value will be +1 if we press the 'd' or right arrow key. 
        float vertical = Input.GetAxisRaw("Vertical");// since we don't want anykind of input smoothing. its value will be -1 if we press 'w' key or up arrow key and value will be +1 if we press 's' key or down arrow key.

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {   
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;// Atan2 is the mathematical function that returns the angle between x axis and the vector starting at 0 and terminating at x , y .
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);// setting the angle for rotation
            Vector3 movDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(movDir.normalized * speed * Time.deltaTime);
        }

    }
}
