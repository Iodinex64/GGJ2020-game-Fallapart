using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : MonoBehaviour
{

    private Rigidbody2D rb;
    public float speed;
    public GameObject pl;

    void Start()
    {
        pl = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        if (pl.GetComponent<PlayerBase>().facingRight)
        {
            rb.velocity = transform.right * speed;
        }
        else
        {
            rb.velocity = (transform.right * -1f) * speed;
        }
        Invoke("Kill", 10f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Kill();
    }

    void Kill()
    {
        Destroy(gameObject);
    }
}
