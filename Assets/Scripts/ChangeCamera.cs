using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    GameObject player;
    CameraScript cam;
    public bool changeCamera;
    public Vector3 offset;
    public Vector3 size;
    bool check;
    bool once;
    public Vector3 maxExt;
    public Vector3 minExt;
    Vector3 nMaxExt;
    Vector3 nMinExt;
    Vector3 initalPosition;
    Vector3 center;
    // Start is called before the first frame update
    void Start()
    {
        center = transform.position + offset;
        player = GameObject.FindGameObjectWithTag("Player");
        cam = FindObjectOfType<CameraScript>();
        initalPosition = cam.position;
        nMinExt = transform.rotation * minExt;
        nMaxExt = transform.rotation * maxExt;
    }

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

    bool previousCheck;

    // Update is called once per frame
    void Update()
    {
        if(!check && previousCheck)
        {
            cam.position = transform.position;
            if (!changeCamera)
            {
                if (cam.cameraTypes == CameraScript.CameraTypes.dolly)
                {
                    cam.position = initalPosition;
                    cam.cameraTypes = CameraScript.CameraTypes.mouseControl;
                }
                else
                {
                    cam.cameraTypes = CameraScript.CameraTypes.dolly;
                }
            }
        }
        previousCheck = check;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.rotation * minExt, transform.rotation * maxExt);
        Gizmos.DrawLine(transform.rotation * minExt, transform.rotation * new Vector3(maxExt.x, minExt.y, minExt.z));
        Gizmos.DrawLine(transform.rotation * new Vector3(minExt.x, maxExt.y, minExt.z), transform.rotation * new Vector3(maxExt.x, maxExt.y, minExt.z));
        Gizmos.DrawLine(transform.rotation * new Vector3(minExt.x, minExt.y, minExt.z), transform.rotation * new Vector3(minExt.x, maxExt.y, minExt.z));
        Gizmos.DrawLine(transform.rotation * new Vector3(maxExt.x, minExt.y, minExt.z), transform.rotation * new Vector3(maxExt.x, maxExt.y, minExt.z));
        Gizmos.DrawLine(transform.rotation * new Vector3(minExt.x, minExt.y, maxExt.z), transform.rotation * new Vector3(maxExt.x, minExt.y, maxExt.z));
        Gizmos.DrawLine(transform.rotation * new Vector3(minExt.x, maxExt.y, maxExt.z), transform.rotation * new Vector3(maxExt.x, maxExt.y, maxExt.z));
        Gizmos.DrawLine(transform.rotation * new Vector3(minExt.x, minExt.y, maxExt.z), transform.rotation * new Vector3(minExt.x, maxExt.y, maxExt.z));
        Gizmos.DrawLine(transform.rotation * new Vector3(maxExt.x, minExt.y, maxExt.z), transform.rotation * new Vector3(maxExt.x, maxExt.y, maxExt.z));
        Gizmos.DrawLine(transform.rotation * new Vector3(minExt.x, minExt.y, minExt.z), transform.rotation * new Vector3(minExt.x, minExt.y, maxExt.z));
        Gizmos.DrawLine(transform.rotation * new Vector3(minExt.x, maxExt.y, minExt.z), transform.rotation * new Vector3(minExt.x, maxExt.y, maxExt.z));
        Gizmos.DrawLine(transform.rotation * new Vector3(maxExt.x, minExt.y, minExt.z), transform.rotation * new Vector3(maxExt.x, minExt.y, maxExt.z));
        Gizmos.DrawLine(transform.rotation * new Vector3(maxExt.x, maxExt.y, minExt.z), transform.rotation * new Vector3(maxExt.x, maxExt.y, maxExt.z));
    }
}
