using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    float Length,startposX;
    public Camera cam;
    public float ParallaxEffect;

    void Start()
    {
        startposX = transform.position.x;
        Length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void FixedUpdate()
    {
        float distX = cam.transform.position.x * ParallaxEffect;

        transform.position = new Vector3(startposX + distX, transform.position.y, transform.position.z);
    }
}
