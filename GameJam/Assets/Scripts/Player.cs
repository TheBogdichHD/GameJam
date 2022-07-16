using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    protected BoxCollider2D boxCollider;
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
    public bool isCollided;
    private (float x, float y) lastCoord;

    public ParticleSystem dust;
    //                          5
    public Sprite[] cube; // 0  1  2  3
    //                          4
    private int[] cubeInt;
    [SerializeField]
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
        isCollided = false;
        lastCoord = (transform.position.x, transform.position.y);
        SetEdges();
    }
    
    private void FixedUpdate()
    {
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || goLeft) && !goDown && !goRight && !goUp)
        {
            currentInt = cubeInt[2];
            goLeft = true;
            if (!isDirty && !isCollided)
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
                lastCoord = (transform.position.x, transform.position.y);
                if (!isSliding && !isCollided)
                {
                    goLeft = false;
                    cubeInt = new int[] { cubeInt[1], cubeInt[2], cubeInt[3], cubeInt[0], cubeInt[4], cubeInt[5] };
                    spriteRenderer.sprite = cube[2];
                    cube = new Sprite[] { cube[1], cube[2], cube[3], cube[0], cube[4], cube[5] };
                    SetEdges();
                }
                if (isDirty && !isCollided)
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
            if (!isDirty && !isCollided)
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
                lastCoord = (transform.position.x, transform.position.y);
                if (!isSliding && goRight && !isCollided)
                {
                    goRight = false;
                    cubeInt = new int[] { cubeInt[3], cubeInt[0], cubeInt[1], cubeInt[2], cubeInt[4], cubeInt[5] };
                    spriteRenderer.sprite = cube[0];
                    cube = new Sprite[] { cube[3], cube[0], cube[1], cube[2], cube[4], cube[5] };
                    SetEdges();
                }
                if (isDirty && !isCollided)
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
            if (!isDirty && !isCollided)
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
                lastCoord = (transform.position.x, transform.position.y);
                if (!isSliding && goUp && !isCollided)
                {
                    goUp = false;
                    cubeInt = new int[] { cubeInt[0], cubeInt[4], cubeInt[2], cubeInt[5], cubeInt[3], cubeInt[1] };
                    spriteRenderer.sprite = cube[4];
                    cube = new Sprite[] { cube[0], cube[4], cube[2], cube[5], cube[3], cube[1] };
                    SetEdges();
                }
                if (isDirty && !isCollided)
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
            if (!isDirty && !isCollided)
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
                lastCoord = (transform.position.x, transform.position.y);
                if (!isSliding && goDown && !isCollided)
                {
                    goDown = false;
                    cubeInt = new int[] { cubeInt[0], cubeInt[5], cubeInt[2], cubeInt[4], cubeInt[1], cubeInt[3] };
                    spriteRenderer.sprite = cube[5];
                    cube = new Sprite[] { cube[0], cube[5], cube[2], cube[4], cube[1], cube[3] };
                    SetEdges();
                }
                if (isDirty && !isCollided)
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Fence")
        {
            isCollided = true;
        }
        transform.position = new Vector3(lastCoord.x, lastCoord.y, 0);
        currentDistance = 0;
        currentInt = cubeInt[1];
        goLeft = false;
        goRight = false;
        goUp = false;
        goDown = false;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isCollided = false;
    }
}
