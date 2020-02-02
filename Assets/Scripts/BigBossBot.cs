using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBossBot : MonoBehaviour
{
    
    private Rigidbody2D rb;
    public float speed;
    public int hp;
    public Vector3 scale;
    public bool speedSwitch;
    [SerializeField]
    GameObject sign;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke("FlipDirection", Random.Range(0.5f, 3f));
        hp = 40;
        scale = new Vector3( 2, 2 ,2 );
        speedSwitch = true;
    }

    void Update()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pellet"))
        {
            hp--;
            if (hp < 20)
            {
                transform.localScale = scale;
                if (speedSwitch){
                    speed = speed / 2;
                    speedSwitch = false;
                }
            }
            if( hp <= 0)
            {
                sign.SetActive(true);
                Destroy(gameObject);
            }
        }
    }

    void FlipDirection()
    {
        speed *= -1;
        transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1f);
        if (hp < 20)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x) * 2, 2f); ;
        }
        Invoke("FlipDirection", Random.Range(0.5f, 3f));

    }
}

