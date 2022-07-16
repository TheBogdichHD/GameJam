using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    protected BoxCollider2D boxCollider;
    protected RaycastHit2D hit;
    private SpriteRenderer spriteRenderer;
    private float movementDistance = 0.02f;
    private float maxDistance = 0.32f;
    private float currentDistance;
    private bool goLeft;
    private bool goRight;
    private bool goUp;
    private bool goDown;
    private bool dustPlay;

    public ParticleSystem dust;
<<<<<<< Updated upstream
=======
    //                          5
    public Sprite[] cube; // 0  1  2  3
    //                          4
    private int[] cubeInt;
    public int currentInt;

    public SpriteRenderer[] edges;
>>>>>>> Stashed changes

    protected void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentDistance = 0;
        goLeft = false;
        goRight = false;
        goUp = false;
        goDown = false;
        dustPlay = false;
    }
    
    private void FixedUpdate()
    {
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || goLeft) && !goDown && !goRight && !goUp)
        {
            goLeft = true;
            currentDistance += movementDistance;
            transform.position += new Vector3(-movementDistance, 0, 0);
            if (currentDistance >= maxDistance)
            {
                currentDistance = 0;
                goLeft = false;
            }
        }

        else if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || goRight) && !goDown && !goLeft && !goUp)
        {
            goRight = true;
            currentDistance += movementDistance;
            transform.position += new Vector3(movementDistance, 0, 0);
            if (currentDistance >= maxDistance)
            {
                currentDistance = 0;
                goRight = false;
            }
        }

        else if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || goUp) && !goDown && !goRight && !goLeft)
        {
            goUp = true;
            currentDistance += movementDistance;
            transform.position += new Vector3(0, movementDistance, 0);
            if (currentDistance >= maxDistance)
            {
                currentDistance = 0;
                goUp = false;
            }
        }

        else if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) || goDown) && !goLeft && !goRight && !goUp)
        {
            goDown = true;
            currentDistance += movementDistance;
            transform.position += new Vector3(0, -movementDistance, 0);
            if (currentDistance >= maxDistance)
            {
                currentDistance = 0;
                goDown = false;
            }
        }
        //transform.position += new Vector3(-movementDistance, 0, 0);
        if (goDown || goLeft || goRight || goUp)
        {
            CreateDust();           
        }
    }

    void CreateDust()
    {       
        dust.Play();
    }
}
