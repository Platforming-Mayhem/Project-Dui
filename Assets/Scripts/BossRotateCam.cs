using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRotateCam : MonoBehaviour
{
    NewPlayerScript play;
    // Start is called before the first frame update
    void Start()
    {
        play = FindObjectOfType<NewPlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Direction = (play.transform.position - transform.position);
        transform.LookAt(Direction);
    }
}
