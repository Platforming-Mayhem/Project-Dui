using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMorph : MonoBehaviour
{
    public MorphingLevelScript morph;
    GameObject player;
    public Vector3 maxExt;
    public Vector3 minExt;
    Vector3 nMaxExt;
    Vector3 nMinExt;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
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

    // Update is called once per frame
    void Update()
    {
        if (check)
        {
            morph.hasBeenTriggered = true;
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
