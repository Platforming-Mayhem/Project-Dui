using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public enum CameraTypes { mouseControl, dolly};
    public CameraTypes cameraTypes;
    public GameObject player;
    public Vector3 position;
    public float speed;
    Vector3 initialPosition;
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        Cursor.lockState = CursorLockMode.Locked;
        cam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(cameraTypes == CameraTypes.mouseControl)
        {
            transform.position = Vector3.Lerp(transform.position, player.transform.position, Time.deltaTime * 10f);
            transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y, 0f);
            transform.eulerAngles += Vector3.up * Time.deltaTime * Input.GetAxis("Mouse X") * speed;
        }
        else if(cameraTypes == CameraTypes.dolly)
        {

        }
    }
}
