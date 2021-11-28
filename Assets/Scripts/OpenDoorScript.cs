using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorScript : MonoBehaviour
{
    CollisionMorph morph;
    InventoryScript inv;
    public Animator door;
    // Start is called before the first frame update
    void Start()
    {
        morph = FindObjectOfType<CollisionMorph>();
        inv = FindObjectOfType<InventoryScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (morph.trigger)
        {
            if(inv.ReadKey() >= 3)
            {
                door.SetTrigger("Open");
            }
        }
    }
}
