using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampSocketScriptthing : MonoBehaviour
{

    private TorchScript torch;

    void Start()
    {
        torch = GameObject.FindGameObjectWithTag("torchobject").GetComponent<TorchScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount > 0)
        {
            torch.isEquipped = true;
        }
    }
}
