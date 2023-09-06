using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody rb;
    float rotationY = 0.0f;
    public float speedvalue = 0.5f;
    public float rotationSpeed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float vInput = Input.GetAxis("Vertical");
        float hInput = Input.GetAxis("Horizontal");
        Vector3 forwardMovement = vInput * transform.forward;
        Vector3 rightMovement = hInput * transform.right;
        Vector3 direction = (forwardMovement + rightMovement);
        direction.Normalize();

        float mouseX = Input.GetAxis("Mouse X");

        rb.AddForce(direction * speedvalue);
        rotationY += mouseX * Time.deltaTime * rotationSpeed;
        transform.rotation = Quaternion.Euler(0.0f,rotationY,0.0f);
    }
}
