using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyColour : MonoBehaviour
{
    Camera cam;
    CollisionMorph morph;
    public Color init;
    public Color darker;
    bool start;
    // Start is called before the first frame update
    void Start()
    {
        morph = GetComponent<CollisionMorph>();
        cam.backgroundColor = init;
        start = false;
    }

    // Update is called once per frame
    void Update()
    {
        cam = FindObjectOfType<Camera>();
        if (morph.nTrig)
        {
            start = true;
        }
        if (start)
        {
            cam.backgroundColor = darker;
        }
    }
}
