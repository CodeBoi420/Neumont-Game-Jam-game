using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookScript : MonoBehaviour
{
    public float sensitivity = 5f;
    private float yRotation = 0f;
    private float xRotation = 0f;
    private Transform cam;

    void Start()
    {
        cam = transform.GetChild(0);
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        yRotation += mouseX;
        xRotation -= mouseY;

        // Clamp rotations to 180 degrees
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Rotate player (y axis)
        transform.localRotation = Quaternion.Euler(0f, yRotation, 0f);

        // Rotate camera (x axis)
        cam.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}