using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouse : MonoBehaviour
{
    [Header("Mouse Sensitivity Attributes")]
    [SerializeField] float mouseSens = 1f;
    [SerializeField] float yRot = 0f;

    [SerializeField] Transform playerBody;


    void Start()
    {
        // Get transform component of current parent object
        playerBody = transform.parent;
        if (playerBody == null)
        {
            Debug.LogError("Parent not found");
        }
    }


    void Update()
    {
        // X Y mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        // Mouse horizontal and vertical rotation
        yRot -= mouseY;
        yRot = Mathf.Clamp(yRot, -90f, 90f);
        transform.localRotation = Quaternion.Euler(yRot, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
