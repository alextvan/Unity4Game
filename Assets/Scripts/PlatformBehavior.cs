using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehavior : MonoBehaviour
{
    [Header("Game Event System Attributes")]
    public int ranPlat;
    public float timer;
    public int gameEvents = 0;
    public int score = 0;

    [Header("Platform Attributes")]
    public List<GameObject> platformsNotChosen = new List<GameObject>();
    public float timeToSinkRise = 4f;
    [SerializeField] bool oneTimer = false;

    [Header("Platform References")]
    [SerializeField] GameObject planks;
    [SerializeField] GameObject redPlatform;
    [SerializeField] GameObject greenPlatform;
    [SerializeField] GameObject bluePlatform;
    [SerializeField] GameObject yellowPlatform;

    void Start()
    {
        // Always initialize to 0 at the start for the menu
        gameEvents = 0;
    }

    void Update()
    {
        // Switch case handles platform behavior. 
        // 0 = Menu, 1 = Selecting platform, 2 = Sink, 3 = Rise
        switch (gameEvents)
        {
            case 0:
                break;
            case 1:
                // Timer, resets every certain amount of seconds, rate allows the timer to go faster.
                if (!oneTimer)
                {
                    // Choose a random time to select a platform
                    timer = Random.Range(1.5f, 10f);
                    oneTimer = true;
                }

                timer -= Time.deltaTime;
                if (timer <= 0f)
                {

                    platChoosing(); // Function call for choosing the platform
                    timer = 10f;

                    gameEvents = 2;
                    oneTimer = false;
                }
                break;

            case 2:
                timeToSinkRise -= Time.deltaTime;
                if (timeToSinkRise >= 0)
                {
                    PlatformsSink();

                }
                else if (timeToSinkRise <= -1.5)
                {
                    timeToSinkRise = 4;
                    gameEvents = 3;
                }
                break;
            case 3:
                timeToSinkRise -= Time.deltaTime;
                if (timeToSinkRise >= 0)
                {
                    PlatformsRise();

                }
                else if (timeToSinkRise <= -1.5)
                {
                    timeToSinkRise = 4;
                    gameEvents = 1;
                    score++;
                    platformsNotChosen.Clear();
                }
                break;
        }
    }

    // Chooses a platform and puts the other platforms in a list, used to translate towards later on.
    private void platChoosing()
    {
        // Generate a random number 1 through 4
        ranPlat = Random.Range(1, 5);
        // RED = 1, BLUE = 2, YELLOW = 3, GREEN = 4
        if (ranPlat == 1)
        {
            platformsNotChosen.Add(bluePlatform);
            platformsNotChosen.Add(yellowPlatform);
            platformsNotChosen.Add(greenPlatform);
        }
        else if (ranPlat == 2)
        {
            platformsNotChosen.Add(redPlatform);
            platformsNotChosen.Add(yellowPlatform);
            platformsNotChosen.Add(greenPlatform);
        }
        else if (ranPlat == 3)
        {
            platformsNotChosen.Add(redPlatform);
            platformsNotChosen.Add(bluePlatform);
            platformsNotChosen.Add(greenPlatform);
        }
        else
        {
            platformsNotChosen.Add(bluePlatform);
            platformsNotChosen.Add(redPlatform);
            platformsNotChosen.Add(yellowPlatform);
        }
    }

    // Platforms Drop, takes in the list of platforms that were not chosen and makes them sink.
    private void PlatformsSink()
    {
        Vector3 sink = new Vector3(0, -0.1f, 0);
        Vector3 plankSink = new Vector3(0, -0.03f, 0);
        foreach (GameObject platform in platformsNotChosen)
        {
            platform.transform.Translate(sink * Time.deltaTime);
            planks.transform.Translate(plankSink * Time.deltaTime);
        }

    }

    // Platforms Rise, takes in the list of platforms that were not chosen and makes them rise.
    private void PlatformsRise()
    {
        Vector3 rise = new Vector3(0, 0.1f, 0);
        Vector3 plankRise = new Vector3(0, 0.03f, 0);
        foreach (GameObject platform in platformsNotChosen)
        {
            platform.transform.Translate(rise * Time.deltaTime);
            planks.transform.Translate(plankRise * Time.deltaTime);
        }
    }
}
