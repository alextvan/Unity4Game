using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MenuCamera : MonoBehaviour
{
    // References to game objects.
    [Header("Camera Settings")]
    [SerializeField] Camera menuCamera;
    [SerializeField] Camera playerCamera;
    [SerializeField] PlatformBehavior platScript;
    [SerializeField] float camRotSpeed = 0.009f;
    public bool disableControls = true;

    // References to canvas'
    [Header("Canvas references")]
    [SerializeField] GameObject menuCanvas;
    [SerializeField] GameObject gameCanvas;
    [SerializeField] GameObject tutorialCanvas;
    [SerializeField] GameObject aboutCanvas;

    // References to audios being used
    [Header("Audio Settings")]
    [SerializeField] AudioSource backgroundMusic;
    [SerializeField] AudioSource buttonClick;

    void Start()
    {
        backgroundMusic.Play();
        // Automatically disable player camera and enable menu camera
        menuCamera.enabled = true;
        playerCamera.enabled = false;

        // Handles canvas activations
        menuCanvas.GetComponent<Canvas>().enabled = true;
        gameCanvas.GetComponent<Canvas>().enabled = false;
        tutorialCanvas.SetActive(false);
        aboutCanvas.SetActive(false);
    }


    void Update()
    {

        // In the case that the game event is 0, we are at the menu. Proceed with menu functionality.
        if (platScript.gameEvents == 0)
        {
            menuCamera.enabled = true;
            playerCamera.enabled = false;
            disableControls = true;
            transform.Rotate(Vector3.up * camRotSpeed);

        }
        else if (platScript.gameEvents == 1)
        {
            // When pressing play, enable the game canvas
            menuCanvas.GetComponent<Canvas>().enabled = false;
            gameCanvas.GetComponent<Canvas>().enabled = true;
            tutorialCanvas.SetActive(false);
            aboutCanvas.SetActive(false);
        }
    }

    // Play Button function handles several mechanics in alternating and disabling the menu camera, vice versa for player camera. Set game event platscript to 1, and enables controls of the characters.
    public void playButton()
    {
        buttonClick.Play();
        disableControls = false;
        menuCamera.enabled = false;
        playerCamera.enabled = true;
        platScript.gameEvents = 1;
    }

    // Enables the tutorial canvas
    public void tutorialButton()
    {
        buttonClick.Play();
        tutorialCanvas.SetActive(true);
    }

    // Disable the tutorial canvas
    public void xTutorialButton()
    {
        buttonClick.Play();
        tutorialCanvas.SetActive(false);
    }

    // Enables the about canvas
    public void aboutButton()
    {
        buttonClick.Play();
        aboutCanvas.SetActive(true);
    }

    // Disable the about canvas
    public void xAboutButton()
    {
        buttonClick.Play();
        aboutCanvas.SetActive(false);
    }
}
