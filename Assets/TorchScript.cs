using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class TorchScript : MonoBehaviour
{
    public bool isEquipped = false;
    private Light2D gLight;

    private void Start()
    {
        gLight = GameObject.FindGameObjectWithTag("globallight").GetComponent<Light2D>();
    }

    private void Update()
    {
        ManageLightLevels();
    }

    void ManageLightLevels()
    {
        if (isEquipped)
        {
            gLight.intensity = 0.45f;
        }
        else
        {
            gLight.intensity = 0.15f;
        }
    }

}
