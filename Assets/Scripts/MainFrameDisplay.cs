using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainFrameDisplay : MonoBehaviour
{
    [Header("Display Settings")]
    [SerializeField] TextMeshPro text;
    [SerializeField] PlatformBehavior platScript;

    void Start()
    {
        // Get the text component of this object
        text = GetComponent<TextMeshPro>();
    }

    void Update()
    {
        // This switch case helps display to the user on the board when the system is choosing a color.
        switch (platScript.gameEvents)
        {
            case 0:
                text.text = "";
                break;
            case 1:
                text.text = "Choosing Color...";
                break;
            case 2:
                text.text = "Platforms sinking";
                break;
            case 3:
                text.text = "Get ready for the next color!";
                break;
        }
    }
}