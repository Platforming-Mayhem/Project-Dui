using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionMorph : MonoBehaviour
{
    public Animator animator;
    bool trigger = false;
    float t = 0f;
    public MeshCollider meshCollider;
    public GameObject GUI;
    public GameObject NPCDialogue;
    Mesh mesh;

    // Start is called before the first frame update
    private void Start()
    {
        mesh = new Mesh();
        GUI.SetActive(false);
        NPCDialogue.SetActive(false);
    }

    private void LateUpdate()
    {
        if (nTrig)
        {
            meshCollider.GetComponent<SkinnedMeshRenderer>().BakeMesh(mesh);
            meshCollider.sharedMesh = mesh;
        }
    }
    public void Morph()
    {
        nTrig = true;
        GUI.SetActive(false);
        NPCDialogue.SetActive(false);
    }
    public void Minimise()
    {
        GUI.SetActive(false);
        NPCDialogue.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
    public bool nTrig;
    // Update is called once per frame
    void Update()
    {
        if (trigger)
        {
            NPCDialogue.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            trigger = false;
        }
        if (nTrig)
        {
            t += Time.deltaTime;
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
            Minimise();
            if (nTrig)
            {
                GetComponent<Collider>().enabled = false;
                nTrig = false;
            }
        }
    }
}
