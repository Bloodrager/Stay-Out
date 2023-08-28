using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{

    public Material blue;
    public Material red;
    Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = blue;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fence")
        {
            rend.sharedMaterial = red;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        rend.sharedMaterial = blue;
    }
}
