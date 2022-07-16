using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge : MonoBehaviour
{
    private SpriteRenderer sr;
    private bool isTouched;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.color = new Color(255, 255, 255, 0);
        isTouched = false;
    }

    void Update()
    {
        if (isTouched)
        {
            if (sr.color.a < 0.7)
                sr.color = new Color(255, 255, 255, sr.color.a + 0.03f);
        }
        else
        {
            if (sr.color.a > 0)
                sr.color = new Color(255, 255, 255, sr.color.a - 0.03f);
        }
    }

    private void OnMouseEnter()
    {
        isTouched = true;   
    }

    private void OnMouseExit()
    {
        isTouched = false;
    }
}
