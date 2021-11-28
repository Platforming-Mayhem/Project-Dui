using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnceTriggered : MonoBehaviour
{
    CollisionMorph morph;
    public GameObject[] gameObjects;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < gameObjects.Length; i++)
        {
            gameObjects[i].SetActive(true);
        }
        morph = GetComponent<CollisionMorph>();
    }
    bool once = false;
    // Update is called once per frame
    void Update()
    {
        if (morph.trigger)
        {
            once = true;
        }
        if (once)
        {
            for (int i = 0; i < gameObjects.Length; i++)
            {
                gameObjects[i].SetActive(false);
            }
            once = false;
        }
    }
}
