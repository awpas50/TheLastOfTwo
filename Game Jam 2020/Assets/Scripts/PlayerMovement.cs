using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject mainCam;
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
        if (Input.GetKey(left))
        {
            transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * rotationSpeed, Space.Self);
        }
        if (Input.GetKey(right))
        {
            transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * rotationSpeed, Space.Self);
        }
        Vector3 yRotation = Vector3.up * rotation * rotationSpeed * Time.fixedDeltaTime;
        Quaternion deltaRotation = Quaternion.Euler(yRotation);
        Quaternion targetRotation = rb.rotation * deltaRotation;
        if (Input.GetKey(up))
        {
            rb.MovePosition(rb.position + transform.forward * moveSpeed * Time.fixedDeltaTime);
        }
        if (Input.GetKey(down))
        {
            rb.MovePosition(rb.position + transform.forward * -moveSpeed * Time.fixedDeltaTime);
        }
        //if (Input.GetKey(left))
        //{
        //    rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, 50f * Time.deltaTime));
        //}
        //if (Input.GetKey(right))
        //{
        //    rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, 50f * Time.deltaTime));
        //}
    }
}
