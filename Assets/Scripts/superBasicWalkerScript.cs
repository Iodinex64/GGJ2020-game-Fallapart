using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class superBasicWalkerScript : MonoBehaviour
{
    
    private Rigidbody2D rb;
    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke("FlipDirection", Random.Range(0.5f, 3f));
    }

    void Update()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pellet"))
        {
            Destroy(gameObject);
        }
    }

    void FlipDirection()
    {
        speed *= -1;
        transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1f);
        Invoke("FlipDirection", Random.Range(0.5f, 3f));

    }
}
