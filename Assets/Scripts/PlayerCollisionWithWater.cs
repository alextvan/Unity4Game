using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollisionWithWater : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] PlatformBehavior platScript;
    [SerializeField] Transform playerPosition;
    [SerializeField] Vector3 initPos;
    [SerializeField] Slider sliderSprint;
    [SerializeField] CharacterMovement characterMovementScript;

    [SerializeField] GameObject menuCanvas;
    [SerializeField] GameObject gameCanvas;

    [Header("Environment Positions")]
    [SerializeField] Transform plankPos;
    [SerializeField] Transform redB;
    [SerializeField] Transform greenB;
    [SerializeField] Transform blueB;
    [SerializeField] Transform yellowB;

    [SerializeField] Vector3 initPlankPos;
    [SerializeField] Vector3 initredB;
    [SerializeField] Vector3 initgreenB;
    [SerializeField] Vector3 initblueB;
    [SerializeField] Vector3 inityellowB;

    [Header("Audio Settings")]
    [SerializeField] AudioSource gameOverAudio;

    void Start()
    {
        // Capture the initial position of the player
        initPos = playerPosition.position;
        initPlankPos = plankPos.position;
        initredB = redB.transform.position;
        initgreenB = greenB.transform.position;
        initblueB = blueB.transform.position;
        inityellowB = yellowB.transform.position;

    }

    void Update()
    {
        // In the case that the position of the player is less than the specified: 0.78, game resets and the game is over.
        if (playerPosition.position.y < 0.78)
        {
            platScript.score = 0;
            platScript.gameEvents = 0;
            playerPosition.position = initPos;
            sliderSprint.value = 1;

            // Disable game canvas and enable menu canvas
            menuCanvas.GetComponent<Canvas>().enabled = true;
            gameCanvas.GetComponent<Canvas>().enabled = false;

            characterMovementScript.movementSpeed = 3f;

            // Reset positions of the blocks in the environment
            plankPos.position = initPlankPos;
            redB.position = initredB;
            greenB.position = initgreenB;
            blueB.position = initblueB;
            yellowB.position = inityellowB;

            // Reset the timr to sink, in doing so we prevent a pause
            platScript.timeToSinkRise = 4f;

            // Clear the platforms that are not chosen
            platScript.platformsNotChosen.Clear();

            // Reset the slider's interactability.
            characterMovementScript.sliderInteract = false;

            //Play Audio
            gameOverAudio.Play();
        }
    }
}
