using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    GameObject player;
    CameraScript cam;
    bool check;
    public bool onlyMouse;
    public Vector3 maxExt;
    public Vector3 minExt;
    Vector3 nMaxExt;
    Vector3 nMinExt;
    Vector3 initalPosition;
    // Start is called before the first frame update
    void Start()
    {
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
        float dot = Vector3.Dot(transform.forward, player.transform.forward * player.GetComponent<PlayerScript>().lastInput.y);
        if(!check && previousCheck)
        {
            Debug.Log("Collide");
            if (!onlyMouse)
            {
                cam.position = transform.position;
                if (cam.cameraTypes == CameraScript.CameraTypes.dolly)
                {
                    if (dot < 0f)
                    {
                        cam.position = initalPosition;
                        cam.cameraTypes = CameraScript.CameraTypes.mouseControl;
                    }
                }
                else
                {
                    if (dot > 0f)
                    {
                        cam.cameraTypes = CameraScript.CameraTypes.dolly;
                    }
                }
            }
            else
            {
                cam.position = initalPosition;
                cam.cameraTypes = CameraScript.CameraTypes.mouseControl;
            }
        }
        previousCheck = check;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(nMinExt, nMaxExt);
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.rotation * minExt, transform.rotation * maxExt);
    }
}
