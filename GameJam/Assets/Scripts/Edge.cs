using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge : MonoBehaviour
{
    private SpriteRenderer sr;
    private bool isTouched;
    private Player pl;
    public Vector3 offset;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.color = new Color(255, 255, 255, 0);
        isTouched = false;
        pl = GetComponentInParent<Player>();
    }

    void Update()
    {
        transform.position = pl.transform.position + offset;
        if (isTouched && !(pl.goUp || pl.goDown || pl.goLeft || pl.goRight))
        {
            if (sr.color.a < 0.7)
                sr.color = new Color(255, 255, 255, sr.color.a + 0.03f);
        }
        else
        {
            if (sr.color.a > 0)
                sr.color = new Color(255, 255, 255, sr.color.a - 0.04f);
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
