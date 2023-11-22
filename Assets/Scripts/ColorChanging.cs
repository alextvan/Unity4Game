using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanging : MonoBehaviour
{
    // Platform Behavior reference
    public PlatformBehavior platformBheaviorscript;

    [Header("Color Picking Settings")]
    [SerializeField] Material color;
    [SerializeField] GameObject cubeChanging;
    [SerializeField] Material defaultColor;

    [SerializeField] float timer = 0.25f;
    [SerializeField] bool colorChanged = false;

    void Start()
    {
        // Initialize game object components and material for the game object itself.
        cubeChanging = gameObject;
        defaultColor = cubeChanging.GetComponent<Renderer>().material;
    }

    void Update()
    {
        // Changes the color of the cube by grabbing a certain color's material and changing the display color. Also set the colorChanged boolean to true to indicate how long the color should be flashed.
        // 1 = Red, 2 = Blue, 3 = Yellow, 4 = Green
        if (platformBheaviorscript.ranPlat == 1)
        {
            cubeChanging.GetComponent<Renderer>().material = GameObject.Find("RED").GetComponent<Renderer>().material;
            colorChanged = true;
        }
        else if (platformBheaviorscript.ranPlat == 2)
        {
            cubeChanging.GetComponent<Renderer>().material = GameObject.Find("BLUE").GetComponent<Renderer>().material;
            colorChanged = true;
        }
        else if (platformBheaviorscript.ranPlat == 3)
        {
            cubeChanging.GetComponent<Renderer>().material = GameObject.Find("YELLOW").GetComponent<Renderer>().material;
            colorChanged = true;
        }
        else if (platformBheaviorscript.ranPlat == 4)
        {
            cubeChanging.GetComponent<Renderer>().material = GameObject.Find("GREEN").GetComponent<Renderer>().material;
            colorChanged = true;
        }
        else
        {
            cubeChanging.GetComponent<Renderer>().material = defaultColor;
        }

        // Color flashes
        if (colorChanged)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                platformBheaviorscript.ranPlat = 0;
                timer = 0.25f;

            }
            colorChanged = false;
        }

    }
}
