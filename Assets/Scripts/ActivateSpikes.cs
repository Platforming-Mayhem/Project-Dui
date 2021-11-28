using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSpikes : MonoBehaviour
{
    Animator anim;
    CollisionMorph morph;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        morph = FindObjectOfType<CollisionMorph>();
    }

    // Update is called once per frame
    void Update()
    {
        if (morph.trigger)
        {
            anim.SetTrigger("Spike");
        }
    }
}
