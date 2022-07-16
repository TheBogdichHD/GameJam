using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    private float maxDistance = 0.05f;
    private float currentDistance;
    private float one;
    private Player pl;

    void Start()
    {
        pl = GameObject.Find("Player").GetComponent<Player>();
        currentDistance = 0;
        one = 1;
    }

    void Update()
    {
        if (currentDistance >= maxDistance)
        {
            currentDistance = 0;
            one *= -1;
        }

        if (!pl.isCollided)
        {
            if (pl.goUp)
                transform.position += new Vector3(0, 0.0004f, 0);
            else if (pl.goDown)
                transform.position += new Vector3(0, -0.0004f, 0);
            else if (pl.goLeft)
                transform.position += new Vector3(-0.0004f, 0, 0);
            else if (pl.goRight)
                transform.position += new Vector3(0.0004f, 0, 0);
        }

        currentDistance += 0.0001f;
        transform.position += new Vector3(0, one * 0.00011f, 0);
    }
}
