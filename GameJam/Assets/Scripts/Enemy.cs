using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int cubeInt;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.name == "Player")
            if (coll.gameObject.GetComponent<Player>().currentInt >= cubeInt)
            {
                this.gameObject.SetActive(false);
            }
    }
}
