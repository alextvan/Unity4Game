using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterAnimation : MonoBehaviour
{
    [SerializeField] float waterSpeed = 0.1f;

    void Update()
    {
        // Moves and offsets the texture of the water
        float offset = Time.time * waterSpeed;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(offset, offset);
    }
}
