using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindComponents : MonoBehaviour
{
    public Transform Ljoint, Rjoint, Ujoint;
    private PlayerBase pl;
    private CircleCollider2D circ;
    List<GameObject> currentCollisions;

    private void Start()
    {
        pl = FindObjectOfType<PlayerBase>();
        circ = GetComponent<CircleCollider2D>();
        currentCollisions = new List<GameObject>();
    }

    public void DropWeapons()
    {
        foreach (GameObject g in currentCollisions)
        {
            if (g.CompareTag("gun") || g.CompareTag("torch") || g.CompareTag("rocket"))
            {
                g.GetComponent<Rigidbody2D>().isKinematic = false;
                g.GetComponent<BoxCollider2D>().isTrigger = false;
                g.transform.parent = null;
            }
        }
        circ.enabled = false;
        pl.hasAtLeastOneComponent = false;
        Invoke("EnablePickup", 3f);
    }

    public void EnablePickup()
    {
        circ.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("gun"))
        {
            collision.transform.rotation = Quaternion.identity;
            currentCollisions.Add(collision.gameObject);
            collision.attachedRigidbody.isKinematic = true;
            collision.GetComponent<BoxCollider2D>().isTrigger = true;
            collision.transform.position = Rjoint.position;
            collision.transform.localScale = pl.transform.localScale;
            collision.transform.parent = Rjoint.transform;
            collision.attachedRigidbody.velocity = new Vector2(0f, 0f);
            pl.hasAtLeastOneComponent = true;
        }

        if (collision.CompareTag("torch"))
        {
            collision.transform.rotation = Quaternion.identity;
            currentCollisions.Add(collision.gameObject);
            collision.attachedRigidbody.isKinematic = true;
            collision.GetComponent<BoxCollider2D>().isTrigger = true;
            collision.transform.position = Ujoint.position;
            collision.transform.localScale = pl.transform.localScale;
            collision.transform.parent = Ujoint.transform;
            collision.attachedRigidbody.velocity = new Vector2(0f, 0f);
            pl.hasAtLeastOneComponent = true;
        }

        if (collision.CompareTag("rocket"))
        {
            collision.transform.rotation = Quaternion.identity;
            currentCollisions.Add(collision.gameObject);
            collision.attachedRigidbody.isKinematic = true;
            collision.GetComponent<BoxCollider2D>().isTrigger = true;
            collision.transform.position = Ljoint.position;
            collision.transform.localScale = pl.transform.localScale;
            collision.transform.parent = Ljoint.transform;
            collision.attachedRigidbody.velocity = new Vector2(0f, 0f);
            pl.hasAtLeastOneComponent = true;
        }
    }
}