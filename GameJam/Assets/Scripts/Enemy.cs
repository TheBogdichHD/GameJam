using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator anim;
    public int cubeInt;
    public ParticleSystem deathEffect;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            if (coll.gameObject.GetComponentInParent<Player>().currentInt >= cubeInt)
            {
                anim.SetBool("isDeath", true);
                CreateDeathEffect();
            }
            else
            {

            }
        }
    }

    void CreateDeathEffect()
    {
        deathEffect.Play();
    }
}
