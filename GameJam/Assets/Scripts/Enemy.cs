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

    private void Start()
    {
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
        if (coll.gameObject.tag == "Player")
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
