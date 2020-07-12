using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float rotationSpeed;

    private float rotation;
    private Rigidbody rb;

    public KeyCode up;
    public KeyCode left;
    public KeyCode down;
    public KeyCode right;

    void Start()
    {
        // player spawn
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rotation = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        if(Input.GetKey(up))
        {
            rb.MovePosition(rb.position + transform.forward * moveSpeed * Time.fixedDeltaTime);
        }
        if (Input.GetKey(down))
        {
            rb.MovePosition(rb.position + transform.forward * -moveSpeed * Time.fixedDeltaTime);
        }
        Vector3 yRotation = Vector3.up * rotation * rotationSpeed * Time.fixedDeltaTime;
        Quaternion deltaRotation = Quaternion.Euler(yRotation);
        Quaternion targetRotation = rb.rotation * deltaRotation;
        if (Input.GetKey(left))
        {
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, 50f * Time.deltaTime));
        }
        if (Input.GetKey(right))
        {
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, 50f * Time.deltaTime));
        }
        
        //transform.Rotate(0f, rotation * rotationSpeed * Time.fixedDeltaTime, 0f, Space.Self);
    }
}
