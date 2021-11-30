using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyColour : MonoBehaviour
{
    Camera cam;
    CollisionMorph morph;
    public Color init;
    public Color darker;
    // Start is called before the first frame update
    void Start()
    {
        morph = GetComponent<CollisionMorph>();
        cam.backgroundColor = init;
    }

    // Update is called once per frame
    void Update()
    {
        cam = FindObjectOfType<Camera>();
        if (morph.nTrig)
        {
            cam.backgroundColor = darker;
        }
    }
}
