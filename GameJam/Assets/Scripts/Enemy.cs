using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator anim;
    public int cubeInt;
    public ParticleSystem deathEffect;
    private bool isDying;
    private float deltaTime;
    public int playerInt;

    private void Start()
    {
        playerInt = -1;
        anim = GetComponent<Animator>();
        isDying = false;
        deltaTime = 0;
    }
    private void Update()
    {
        if (isDying)
        {
            deltaTime += Time.deltaTime;
            if (deltaTime > 1.7f)
            {
                Destroy(gameObject);
            }           
        }
    }
    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player" && coll.gameObject.GetComponent<Player>().currentInt != playerInt)
        {
            if (playerInt == -1)
            {
                playerInt = coll.gameObject.GetComponent<Player>().currentInt;
            }
            else
            {
                if (coll.gameObject.GetComponent<Player>().currentInt >= cubeInt)
                {
                    deathEffect.Play();
                    anim.SetBool("isDeath", true);
                    isDying = true;
                }
                else
                {

                }
            }
           
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        playerInt = -1;
    }
}
