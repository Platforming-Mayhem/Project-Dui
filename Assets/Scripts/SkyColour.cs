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
        cam = FindObjectOfType<Camera>();
        morph = GetComponent<CollisionMorph>();
        cam.backgroundColor = init;
        start = false;
    }

    // Update is called once per frame
    void Update()
    {
        Camera[] cams = (Camera[])Resources.FindObjectsOfTypeAll(typeof(Camera));
        if (morph.nTrig)
        {
            start = true;
        }
        if (start)
        {
            for(int i = 0; i < cams.Length; i++)
            {
                cams[i].backgroundColor = darker;
            }
            start = false;
        }
    }
}
