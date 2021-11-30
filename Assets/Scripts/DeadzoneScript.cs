using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadzoneScript : MonoBehaviour
{
    NewPlayerScript playerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = FindObjectOfType<NewPlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerScript.Die();
        }
    }
}
