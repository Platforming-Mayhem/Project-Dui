using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapTexture : MonoBehaviour
{
    public Texture2D t2D;
    public Texture2D dT2D;
    public Color color;
    public Color darkerColor;
    public Material mat;
    public Material cliff;
    CollisionMorph morph;
    // Start is called before the first frame update
    void Start()
    {
        morph = GetComponent<CollisionMorph>();
        mat.mainTexture = t2D;
        cliff.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        if (morph.nTrig)
        {
            mat.mainTexture = dT2D;
            cliff.color = darkerColor;
        }
    }
}
