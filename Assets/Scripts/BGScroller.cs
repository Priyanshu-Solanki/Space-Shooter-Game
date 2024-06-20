using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    public float scrollSpeed;
    public float maxScrollSpeed;
    public float speedIncreaseFactor;
    public float tileSize;

    private float time=0.0f;
    private Vector3 startPosition;
    void Start()
    {
        startPosition = transform.position;
    }
    void Update()
    {
        time += Time.deltaTime;
        float scrollSpeedOriginal = scrollSpeed;
        float newPosition = Mathf.Repeat(time * scrollSpeed, tileSize);
        transform.position = startPosition + Vector3.forward * newPosition;
        scrollSpeed += -Time.deltaTime * speedIncreaseFactor;
        if (scrollSpeed < maxScrollSpeed)
        {
            scrollSpeed = maxScrollSpeed;
        }
    }

}
