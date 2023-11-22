using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour
{
    [Header("Input Movement Settings")]
    [SerializeField] float sideMov;
    [SerializeField] float frontMov;
    [SerializeField] Vector3 movement;
    public float movementSpeed = 3f;

    [Header("Player Components")]
    [SerializeField] CharacterController controller;
    [SerializeField] Rigidbody playerBody;

    [Header("Gravity Settings")]
    [SerializeField] float gravity = -9.81f;
    [SerializeField] Vector3 downVelocity;

    [SerializeField] MenuCamera cameraMenuScript;

    [Header("Player Settings")]
    [SerializeField] Transform playerPos;
    [SerializeField] Vector3 initPos;

    [Header("Sprint Settings")]
    [SerializeField] float movementSprint = 7.5f;
    [SerializeField] Slider sliderVal;
    [SerializeField] float regenerationMultiplier = 0.15f;
    public bool sliderInteract = false;


    void Start()
    {
        // Get rigidbody, character controller, and position components of this object (The player object)
        controller = GetComponent<CharacterController>();
        playerBody = GetComponent<Rigidbody>();
        initPos = transform.position;

        // Freeze all rigidbody constraints (rotation)
        playerBody.constraints = RigidbodyConstraints.FreezeRotation;

    }

    void Update()
    {

        // When menu camera is disabled, freeze player movement, else gain player input.
        if (cameraMenuScript.disableControls)
        {
            // Don't lock mouse, reset
            Cursor.lockState = CursorLockMode.None;
            transform.position = initPos;
        }
        else
        {
            // Helps decrease the value in the slider when the player sprints
            toggleBar();

            // Lock mouse
            Cursor.lockState = CursorLockMode.Locked;

            // Keyboard input
            sideMov = Input.GetAxisRaw("Horizontal");
            frontMov = Input.GetAxisRaw("Vertical");

            // Character movement
            movement = transform.right * sideMov + transform.forward * frontMov;
            controller.Move(movement * movementSpeed * Time.deltaTime);

            // In the case that we can sprint by holding left shift, change speed
            if (Input.GetKeyDown(KeyCode.LeftShift) && sliderVal.value > 0)
            {
                movementSpeed = movementSprint;
                sliderInteract = true;
            }

            // Upon release, revert back to original speed
            if (Input.GetKeyUp(KeyCode.LeftShift) && sliderVal.value < 1)
            {
                movementSpeed = 3f;
                sliderInteract = false;
            }

            // Character jump, in the case that the character is not grounded, apply gravity.
            if (!controller.isGrounded)
            {
                downVelocity.y += gravity * Time.deltaTime;
                controller.Move(downVelocity * Time.deltaTime);
            }
        }
    }

    // Toggles when the player is sprinting. This allows continuation of the slider value decreasing or increasing.
    void toggleBar()
    {
        if (sliderInteract)
        {
            sliderVal.value -= Time.deltaTime;
        }
        else
        {
            sliderVal.value += Time.deltaTime * regenerationMultiplier;
        }
    }
}
