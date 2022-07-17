using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private SpriteRenderer sr;
    public Sprite btn;
    public GameObject door;
    private bool isOpen;
    private float DTime;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        DTime = 0;
    }

    private void Update()
    {
        if (isOpen)
        {
            DTime += Time.deltaTime;
            if (DTime >= 1)
                Destroy(door.GetComponent<BoxCollider2D>());
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            sr.sprite = btn;
            door.GetComponent<Animator>().SetBool("Btn", true);
            isOpen = true;
        }
    }
}