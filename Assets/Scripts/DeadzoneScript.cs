using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadzoneScript : MonoBehaviour
{
    NewPlayerScript playerScript;
    Boss01Script boss;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = FindObjectOfType<NewPlayerScript>();
        boss = FindObjectOfType<Boss01Script>();
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
        else if (other.CompareTag("Key03"))
        {
            boss.RemoveHealth();
            Destroy(gameObject);
            Debug.Log("YOUUU BE HUR'IN NOW");
        }
    }
}
