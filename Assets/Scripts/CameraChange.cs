using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public Camera cam;
    CameraScript cameraScript;
    // Start is called before the first frame update
    void Start()
    {
        cam.gameObject.SetActive(false);
        cameraScript = FindObjectOfType<CameraScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cameraScript.transform.eulerAngles = new Vector3(cameraScript.transform.eulerAngles.x, cam.transform.eulerAngles.y, cameraScript.transform.eulerAngles.z);
            cam.gameObject.SetActive(true);
            cameraScript.cameraTypes = CameraScript.CameraTypes.dolly;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cam.gameObject.SetActive(false);
            cameraScript.cameraTypes = CameraScript.CameraTypes.mouseControl;
        }
    }
}
