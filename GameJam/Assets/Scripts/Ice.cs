using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
            coll.gameObject.GetComponentInParent<Player>().isSliding = true;
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
            coll.gameObject.GetComponentInParent<Player>().isSliding = false;
    }
}
