using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionMorph : MonoBehaviour
{
    public Animator animator;
    public bool trigger = false;
    float t = 0f;
    public MeshCollider meshCollider;
    public GameObject GUI;
    Mesh mesh;

    // Start is called before the first frame update
    private void Start()
    {
        mesh = new Mesh();
        GUI.SetActive(false);
    }

    private void LateUpdate()
    {
        if (trigger)
        {
            meshCollider.GetComponent<SkinnedMeshRenderer>().BakeMesh(mesh);
            meshCollider.sharedMesh = mesh;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (trigger)
        {
            t += Time.deltaTime;
        }
        if(t > 1f)
        {
            trigger = false;
        }
        animator.SetFloat("Time", t);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GUI.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                trigger = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GUI.SetActive(false);
        }
    }
}
