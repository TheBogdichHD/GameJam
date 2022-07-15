using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    protected BoxCollider2D boxCollider;
    protected RaycastHit2D hit;
    private SpriteRenderer spriteRenderer;
    private float movementDistance = 0.32f;

    protected void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            transform.position += new Vector3(-movementDistance, 0, 0);
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            transform.position += new Vector3(movementDistance, 0, 0);
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            transform.position += new Vector3(0, movementDistance, 0);
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            transform.position += new Vector3(0, -movementDistance, 0);
        
    }
}
