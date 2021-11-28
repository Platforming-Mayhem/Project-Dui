using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    public int keys = 0;

    public void AddKey()
    {
        keys += 1;
    }

    public int ReadKey()
    {
        return keys;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
