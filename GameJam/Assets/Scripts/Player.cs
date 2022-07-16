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
    public bool goLeft;
    public bool goRight;
    public bool goUp;
    public bool goDown;
    public bool isSliding;

    public ParticleSystem dust;
    //                          5
    public Sprite[] cube; // 0  1  2  3
    //                          4
    private int[] cubeInt;
    public int currentInt;

    public SpriteRenderer[] edges;

    protected void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentDistance = 0;
        goLeft = false;
        goRight = false;
        goUp = false;
        goDown = false;
        spriteRenderer.sprite = cube[1];
        cubeInt = new int[] { 2, 1, 5, 6, 4, 3 };
        currentInt = 1;
        isSliding = false;
        SetEdges();
    }
    
    private void FixedUpdate()
    {
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || goLeft) && !goDown && !goRight && !goUp)
        {
            cubeInt = new int[] { cubeInt[1], cubeInt[2], cubeInt[3], cubeInt[0], cubeInt[4], cubeInt[5] };
            goLeft = true;
            currentDistance += movementDistance;
            transform.position += new Vector3(-movementDistance, 0, 0);
            if (currentDistance >= maxDistance)
            {
                currentDistance = 0;
                if (!isSliding)
                {
                    goLeft = false;
                    currentInt = cubeInt[2];
                    spriteRenderer.sprite = cube[2];
                    cube = new Sprite[] { cube[1], cube[2], cube[3], cube[0], cube[4], cube[5] };
                    SetEdges();
                }
            }
        }

        else if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || goRight) && !goDown && !goLeft && !goUp)
        {
            cubeInt = new int[] { cubeInt[3], cubeInt[0], cubeInt[1], cubeInt[2], cubeInt[4], cubeInt[5] };
            goRight = true;
            currentDistance += movementDistance;
            transform.position += new Vector3(movementDistance, 0, 0);
            if (currentDistance >= maxDistance)
            {
                currentDistance = 0;
                if (!isSliding)
                {
                    goRight = false;
                    currentInt = cubeInt[0];
                    spriteRenderer.sprite = cube[0];
                    cube = new Sprite[] { cube[3], cube[0], cube[1], cube[2], cube[4], cube[5] };
                    SetEdges();
                }
            }
        }

        else if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || goUp) && !goDown && !goRight && !goLeft)
        {
            cubeInt = new int[] { cubeInt[0], cubeInt[4], cubeInt[2], cubeInt[5], cubeInt[3], cubeInt[1] };
            goUp = true;
            currentDistance += movementDistance;
            transform.position += new Vector3(0, movementDistance, 0);
            if (currentDistance >= maxDistance)
            {
                currentDistance = 0;
                if (!isSliding)
                {
                    goUp = false;
                    currentInt = cubeInt[4];
                    spriteRenderer.sprite = cube[4];
                    cube = new Sprite[] { cube[0], cube[4], cube[2], cube[5], cube[3], cube[1] };
                    SetEdges();
                }
            }
        }

        else if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) || goDown) && !goLeft && !goRight && !goUp)
        {
            cubeInt = new int[] { cubeInt[0], cubeInt[5], cubeInt[2], cubeInt[4], cubeInt[1], cubeInt[3] };
            goDown = true;
            currentDistance += movementDistance;
            transform.position += new Vector3(0, -movementDistance, 0);
            if (currentDistance >= maxDistance)
            {
                currentDistance = 0;
                if (!isSliding)
                {
                    goDown = false;
                    currentInt = cubeInt[5];
                    spriteRenderer.sprite = cube[5];
                    cube = new Sprite[] { cube[0], cube[5], cube[2], cube[4], cube[1], cube[3] };
                    SetEdges();
                }
            }
        }

        if (goDown || goLeft || goRight || goUp)
        {
            CreateDust();           
        }
    }

    void SetEdges()
    {
        edges[0].sprite = cube[0];
        edges[1].sprite = cube[5];
        edges[2].sprite = cube[2];
        edges[3].sprite = cube[4];
    }

    void CreateDust()
    {       
        dust.Play();
    }
}
