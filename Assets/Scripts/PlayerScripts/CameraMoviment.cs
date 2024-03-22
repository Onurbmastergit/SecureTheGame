using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoviment : MonoBehaviour
{
    public Transform player;
    public Transform pivotPoint;
    public float sensitivity = 2.22f;
    public bool shiftLock = false;

    private float mouseX;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            shiftLock = !shiftLock;
        }

        if (shiftLock || Input.GetMouseButton(0))
        {
            mouseX += Input.GetAxis("Mouse X") * sensitivity;
        }

        // Rotate pivot point around player
        pivotPoint.rotation = Quaternion.Euler(0, mouseX, 0);
        
        // Update camera position
        transform.position = pivotPoint.position;
        transform.rotation = Quaternion.LookRotation(player.position - transform.position, Vector3.up);
    }
}
