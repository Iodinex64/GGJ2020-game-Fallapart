using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunComponent : MonoBehaviour
{
    public GameObject bullet;
    public Transform shotPoint;
    public bool isEquipped = false;
    [SerializeField]
    private AudioClip gunSound;
    private AudioSource audioGun;

    private void Start()
    {
        audioGun = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && isEquipped)
        {
            Instantiate(bullet, shotPoint.position, Quaternion.identity);
            audioGun.PlayOneShot(gunSound);
        }
    }
}