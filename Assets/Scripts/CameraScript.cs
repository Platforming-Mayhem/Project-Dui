using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public Vector3 scale;
    public Vector3 offset;
    Vector3 initialPosition;
    Camera cam;
    bool check;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        Cursor.lockState = CursorLockMode.Locked;
        cam = GetComponentInChildren<Camera>();
    }

    Vector3 maxExt;
    Vector3 minExt;

    private void FixedUpdate()
    {
        maxExt = (transform.position + offset + (scale / 2f));
        minExt = (transform.position + offset - (scale / 2f));
        if(player.transform.position.x < maxExt.x && player.transform.position.x > minExt.x && player.transform.position.z < maxExt.z && player.transform.position.z > minExt.z && player.transform.position.y < maxExt.y && player.transform.position.y > minExt.y)
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
            cam.gameObject.SetActive(true);
            Debug.Log("Colliding, Your chin feels nice");
            transform.LookAt(player.transform);
        }
        else
        {
            cam.gameObject.SetActive(false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(transform.position + offset, scale);
    }
}
