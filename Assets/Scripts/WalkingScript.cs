using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WalkingScript : MonoBehaviour
{
    public Vector3 pointA;
    public Vector3 pointB;
    public float speed = 2.0f;

    private bool flippedAtA = false;
    private bool flippedAtB = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float time = Mathf.PingPong(Time.time * speed, 1.0f);
        transform.position = Vector3.Lerp(pointA, pointB, time);

        float threshold = 0.01f;

        // Check point A
        if (Vector3.Distance(transform.position, pointA) < threshold)
        {
            if (!flippedAtA)    // flip only once
            {
                transform.Rotate(0, 180, 0);
                flippedAtA = true;
                flippedAtB = false;
            }
        }

        // Check point B
        if (Vector3.Distance(transform.position, pointB) < threshold)
        {
            if (!flippedAtB)    // flip only once
            {
                transform.Rotate(0, 180, 0);
                flippedAtB = true;
                flippedAtA = false;
            }
        }
    }
}
