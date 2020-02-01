using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunComponent : MonoBehaviour
{
    public GameObject bullet;
    public Transform shotPoint;
    public bool isEquipped;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && isEquipped)
        {
            Instantiate(bullet, shotPoint.position, Quaternion.identity);
        }
    }
}