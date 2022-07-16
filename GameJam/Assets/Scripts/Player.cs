using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    protected BoxCollider2D boxCollider;
    private Rigidbody2D rigidbody;
    private SpriteRenderer spriteRenderer;
    private float movementDistance = 0.02f;
    private float maxDistance = 0.32f;
    private float currentDistance;
    public bool goLeft;
    public bool goRight;
    public bool goUp;
    public bool goDown;
    public bool isSliding;
    public bool isDirty;

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
        rigidbody = GetComponent<Rigidbody2D>();
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
            currentInt = cubeInt[2];
            goLeft = true;
            if (!isDirty)
            {
                currentDistance += movementDistance;
                transform.position += new Vector3(-movementDistance, 0, 0);
            }
            else
            {
                currentDistance += 0.007f;
                transform.position += new Vector3(-0.007f, 0, 0);
            }
            if (currentDistance >= maxDistance)
            {
                currentDistance = 0;
                if (!isSliding)
                {
                    goLeft = false;
                    cubeInt = new int[] { cubeInt[1], cubeInt[2], cubeInt[3], cubeInt[0], cubeInt[4], cubeInt[5] };
                    spriteRenderer.sprite = cube[2];
                    cube = new Sprite[] { cube[1], cube[2], cube[3], cube[0], cube[4], cube[5] };
                    SetEdges();
                }
                if (isDirty)
                {
                    cubeInt = new int[] { cubeInt[1], cubeInt[2], cubeInt[3], cubeInt[0], cubeInt[4], cubeInt[5] };
                    spriteRenderer.sprite = cube[2];
                    cube = new Sprite[] { cube[1], cube[2], cube[3], cube[0], cube[4], cube[5] };
                    SetEdges();
                    goLeft = true;
                    isDirty = false;
                }
            }
        }

        else if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || goRight) && !goDown && !goLeft && !goUp)
        {
            currentInt = cubeInt[0];
            goRight = true;
            if (!isDirty)
            {
                currentDistance += movementDistance;
                transform.position += new Vector3(movementDistance, 0, 0);
            }
            else
            {
                currentDistance += 0.007f;
                transform.position += new Vector3(0.007f, 0, 0);
            }
            if (currentDistance >= maxDistance)
            {
                currentDistance = 0;
                if (!isSliding)
                {
                    goRight = false;
                    cubeInt = new int[] { cubeInt[3], cubeInt[0], cubeInt[1], cubeInt[2], cubeInt[4], cubeInt[5] };
                    spriteRenderer.sprite = cube[0];
                    cube = new Sprite[] { cube[3], cube[0], cube[1], cube[2], cube[4], cube[5] };
                    SetEdges();
                }
                if (isDirty)
                {
                    cubeInt = new int[] { cubeInt[3], cubeInt[0], cubeInt[1], cubeInt[2], cubeInt[4], cubeInt[5] };
                    spriteRenderer.sprite = cube[0];
                    cube = new Sprite[] { cube[3], cube[0], cube[1], cube[2], cube[4], cube[5] };
                    SetEdges();
                    goRight = true;
                    isDirty = false;
                }
            }
        }

        else if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || goUp) && !goDown && !goRight && !goLeft)
        {
            currentInt = cubeInt[4];
            goUp = true;
            if (!isDirty)
            {
                currentDistance += movementDistance;
                transform.position += new Vector3(0, movementDistance, 0);
            }
            else
            {
                currentDistance += 0.007f;
                transform.position += new Vector3(0, 0.007f, 0);
            }
            if (currentDistance >= maxDistance)
            {
                currentDistance = 0;
                if (!isSliding)
                {
                    goUp = false;
                    cubeInt = new int[] { cubeInt[0], cubeInt[4], cubeInt[2], cubeInt[5], cubeInt[3], cubeInt[1] };
                    spriteRenderer.sprite = cube[4];
                    cube = new Sprite[] { cube[0], cube[4], cube[2], cube[5], cube[3], cube[1] };
                    SetEdges();
                }
                if (isDirty)
                {
                    cubeInt = new int[] { cubeInt[0], cubeInt[4], cubeInt[2], cubeInt[5], cubeInt[3], cubeInt[1] };
                    spriteRenderer.sprite = cube[4];
                    cube = new Sprite[] { cube[0], cube[4], cube[2], cube[5], cube[3], cube[1] };
                    SetEdges();
                    goUp = true;
                    isDirty = false;
                }
            }
        }

        else if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) || goDown) && !goLeft && !goRight && !goUp)
        {
            currentInt = cubeInt[5];
            goDown = true;
            if (!isDirty)
            {
                currentDistance += movementDistance;
                transform.position += new Vector3(0, -movementDistance, 0);
            }
            else
            {
                currentDistance += 0.007f;
                transform.position += new Vector3(0, -0.007f, 0);
            }
            if (currentDistance >= maxDistance)
            {
                currentDistance = 0;
                if (!isSliding)
                {
                    goDown = false;
                    cubeInt = new int[] { cubeInt[0], cubeInt[5], cubeInt[2], cubeInt[4], cubeInt[1], cubeInt[3] };
                    spriteRenderer.sprite = cube[5];
                    cube = new Sprite[] { cube[0], cube[5], cube[2], cube[4], cube[1], cube[3] };
                    SetEdges();
                }
                if (isDirty)
                {
                    currentInt = cubeInt[5];
                    cubeInt = new int[] { cubeInt[0], cubeInt[5], cubeInt[2], cubeInt[4], cubeInt[1], cubeInt[3] };
                    spriteRenderer.sprite = cube[5];
                    cube = new Sprite[] { cube[0], cube[5], cube[2], cube[4], cube[1], cube[3] };
                    goDown = true;
                    isDirty = false;
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
