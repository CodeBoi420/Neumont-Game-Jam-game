using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float speed = 10f;
    public float jumpHeight = 10f;
    public float maxGravity = -3f;
    public float gravityDecAmnt = -0.5f;
    private float x;
    private float z;

    private Rigidbody rb;
    private Vector3 vel;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");

        Vector3 moveDir = (transform.right * x + transform.forward * z).normalized;

        vel = new Vector3(moveDir.x * speed, vel.y, moveDir.z * speed);

        AddGravity();

        // Applies velocity
        rb.velocity = vel;
    }

    private void AddGravity()
    {
        if (!IsGrounded() && vel.y > maxGravity)
        {
            vel.y += gravityDecAmnt;
        }
    }

    void Update()
    {
        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            vel.y = jumpHeight;
        }
    }

    private bool IsGrounded()
    {
        float rayLength = 1.2f;
        int floorLayer = LayerMask.GetMask("Floor");
        Vector3 rayPos = transform.position;
        Debug.DrawRay(rayPos, Vector3.down * rayLength, Color.red);
        return Physics.Raycast(rayPos, Vector3.down, rayLength, floorLayer);
    }
}
