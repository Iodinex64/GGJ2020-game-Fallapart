using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindComponents : MonoBehaviour
{
    public Transform Ljoint, Rjoint, Ujoint;
    private bool Lbool, Rbool, Ubool = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("pickup"))
        {
            collision.GetComponent<BoxCollider2D>().isTrigger = true;
            collision.transform.position = Rjoint.position;
            collision.transform.parent = Rjoint.transform;
            collision.attachedRigidbody.velocity = new Vector2(0f, 0f);
        }
    }
}