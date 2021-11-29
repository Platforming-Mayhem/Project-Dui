using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOnceTriggered : MonoBehaviour
{
    CollisionMorph morph;
    public GameObject[] gameObjects;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < gameObjects.Length; i++)
        {
            gameObjects[i].SetActive(false);
        }
        morph = GetComponent<CollisionMorph>();
    }
    bool once = false;
    // Update is called once per frame
    void Update()
    {
        if (morph.nTrig)
        {
            once = true;
        }
        if (once)
        {
            for (int i = 0; i < gameObjects.Length; i++)
            {
                gameObjects[i].SetActive(true);
            }
            once = false;
        }
    }
}
