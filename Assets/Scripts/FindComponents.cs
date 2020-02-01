using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindComponents : MonoBehaviour
{
    public Transform Ljoint, Rjoint, Ujoint;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("gun"))
        {
            collision.GetComponent<BoxCollider2D>().isTrigger = true;
            collision.transform.position = Rjoint.position;
            collision.transform.parent = Rjoint.transform;
            collision.attachedRigidbody.velocity = new Vector2(0f, 0f);
        }

        if (collision.CompareTag("torch"))
        {
            collision.GetComponent<BoxCollider2D>().isTrigger = true;
            collision.transform.position = Ujoint.position;
            collision.transform.parent = Ujoint.transform;
            collision.attachedRigidbody.velocity = new Vector2(0f, 0f);
        }

        if (collision.CompareTag("rocket"))
        {
            collision.GetComponent<BoxCollider2D>().isTrigger = true;
            collision.transform.position = Ljoint.position;
            collision.transform.parent = Ljoint.transform;
            collision.attachedRigidbody.velocity = new Vector2(0f, 0f);
        }
    }
}