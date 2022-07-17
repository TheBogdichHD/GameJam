using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCMenu : MonoBehaviour
{
    private float maxDistance = 0.05f;
    private float currentDistance;
    private float one;
    private Vector3 v;
    private (float Old, float New) xCoord;
    private (float Old, float New) yCoord;

    void Start()
    {
        currentDistance = 0;
        one = 1;
        xCoord = (0, 0);
        yCoord = (0, 0);
    }

    void Update()
    {
        if (currentDistance >= maxDistance)
        {
            currentDistance = 0;
            one *= -1;
        }

        v = Input.mousePosition;
        xCoord = (xCoord.New, v.x);
        yCoord = (yCoord.New, v.y);

        transform.position += new Vector3(0.0001f * (xCoord.New - xCoord.Old), 0.0001f * (yCoord.New - yCoord.Old), 0);

        currentDistance += 0.0001f;
        transform.position += new Vector3(0, one * 0.0001f, 0);

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.anyKey)
        {
            Counter.instance.LoadNextLevel();
        }
    }
}
