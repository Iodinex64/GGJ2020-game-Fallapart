using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour
{

    public bool isEquipped = false;
    public SpriteRenderer flameSpr;
    private bool canJump;
    public PlayerBase pl;
    public Rigidbody2D plRB;

    private void Start()
    {
        pl = FindObjectOfType<PlayerBase>();
        plRB = FindObjectOfType<PlayerBase>().GetComponent<Rigidbody2D>();
        InvokeRepeating("SpinFlame", 0f, 0.12f);
        TurnOffFlame();
    }

    private void TurnOffFlame()
    {
        flameSpr.gameObject.SetActive(false);
    }

    private void SpinFlame()
    {
        flameSpr.flipX = !flameSpr.flipX;
    }

    private void Update()
    {
        if (pl.grndCheck)
        {
            canJump = true;
        }

        if (Input.GetButtonDown("Jump") && isEquipped)
        {
            if (!pl.grndCheck && canJump)
            {
                Vector2 jumpVelVect = new Vector2(0f, pl.jumpHeight);
                plRB.velocity += jumpVelVect;
                flameSpr.gameObject.SetActive(true);
                Invoke("TurnOffFlame", 0.5f);
                canJump = false;
            }
        }
    }

}
