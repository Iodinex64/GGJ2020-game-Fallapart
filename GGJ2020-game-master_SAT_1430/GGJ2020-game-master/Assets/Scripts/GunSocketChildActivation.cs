using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSocketChildActivation : MonoBehaviour
{

    private GunComponent gun;

    private void Start()
    {
        gun = GameObject.FindGameObjectWithTag("gunobject").GetComponent<GunComponent>();
    }

    private void Update()
    {
        if (transform.childCount > 0)
        {
            gun.isEquipped = true;
        }
    }
}
