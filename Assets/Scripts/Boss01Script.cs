using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss01Script : MonoBehaviour
{
    bool begin;
    int state = 0;
    // Start is called before the first frame update
    void Start()
    {
        begin = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            begin = true;
        }
    }
}
