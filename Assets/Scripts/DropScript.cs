using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropScript : MonoBehaviour
{
    GameObject player;
    MorphingLevelScript levelScript;
    public float Speed;
    public Vector3 maxExt;
    public Vector3 minExt;
    Vector3 nMaxExt;
    Vector3 nMinExt;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        levelScript = FindObjectOfType<MorphingLevelScript>();
        nMinExt = transform.rotation * minExt;
        nMaxExt = transform.rotation * maxExt;
    }
    bool check;

    private void FixedUpdate()
    {
        if (player.transform.position.x < nMaxExt.x && player.transform.position.x > nMinExt.x && player.transform.position.y < nMaxExt.y && player.transform.position.y > nMinExt.y && player.transform.position.z < nMaxExt.z && player.transform.position.z > nMinExt.z)
        {
            check = true;
        }
        else
        {
            check = false;
        }
    }
    bool fall = false;
    // Update is called once per frame
    void Update()
    {
        if (levelScript.hasBeenTriggered)
        {
            if (check)
            {
                fall = true;
            }
        }
        if (fall)
        {
            transform.position += Vector3.down * Speed * Time.deltaTime;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(nMinExt, nMaxExt);
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.rotation * minExt, transform.rotation * maxExt);
    }
}
