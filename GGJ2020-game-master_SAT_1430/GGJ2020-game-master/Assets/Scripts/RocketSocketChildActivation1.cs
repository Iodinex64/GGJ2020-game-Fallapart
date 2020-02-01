using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSocketChildActivation1 : MonoBehaviour
{

    private RocketScript rocket;

    private void Start()
    {
        rocket = GameObject.FindGameObjectWithTag("rocketobject").GetComponent<RocketScript>();
    }

    private void Update()
    {
        if (transform.childCount > 0)
        {
            rocket.isEquipped = true;
        }
    }
}
