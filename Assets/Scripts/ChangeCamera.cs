using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    GameObject player;
    CameraScript cam;
    public Vector3 offset;
    public Vector3 size;
    bool check;
    bool once;
    Vector3 maxExt;
    Vector3 minExt;
    Vector3 initalPosition;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cam = FindObjectOfType<CameraScript>();
        maxExt = transform.position + offset + (size / 2f);
        minExt = transform.position + offset - (size / 2f);
        initalPosition = cam.position;
    }

    private void FixedUpdate()
    {
        if (player.transform.position.x < maxExt.x && player.transform.position.x > minExt.x && player.transform.position.y < maxExt.y && player.transform.position.y > minExt.y && player.transform.position.z < maxExt.z && player.transform.position.z > minExt.z)
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
            if(cam.cameraTypes == CameraScript.CameraTypes.dolly)
            {
                cam.position = initalPosition;
                cam.cameraTypes = CameraScript.CameraTypes.mouseControl;
            }
            else
            {
                cam.position = transform.position;
                cam.cameraTypes = CameraScript.CameraTypes.dolly;
            }
        }
        previousCheck = check;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position + offset, size);
    }
}
