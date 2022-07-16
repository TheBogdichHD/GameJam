using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator anim;
    public int cubeInt;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            if (coll.gameObject.GetComponent<Player>().currentInt >= cubeInt)
            {
                anim.SetBool("isDeath", true);
            }
            else
            {

            }
        }
    }
}
