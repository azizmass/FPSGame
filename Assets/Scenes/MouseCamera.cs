using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCamera : MonoBehaviour
{
    [SerializeField] Rigidbody playerRb;
    [SerializeField] float rotSpeed;
    [SerializeField] float moveSensitivity = 100f;
    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Get the mouse movement on both axis 
        float mouseX = Input.GetAxis("Mouse X") * moveSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * moveSensitivity * Time.deltaTime;

        // Calculate new Rotation
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Rotate player around Y 
        //Returns a rotation that rotates z degrees around the z axis, x degrees around the x axis, and y degrees around the y axis.
        playerRb.rotation = Quaternion.Euler(playerRb.rotation.eulerAngles + Vector3.up * mouseX);

        //Rotate Camera around X
        //Returns a rotation that rotates z degrees around the z axis, x degrees around the x axis, and y degrees around the y axis; applied in that order.
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }
}
