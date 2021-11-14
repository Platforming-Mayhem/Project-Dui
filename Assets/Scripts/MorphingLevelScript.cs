using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorphingLevelScript : MonoBehaviour
{
    public float timeTillTriggered = 0f;
    public bool hasBeenTriggered;
    public Animator EnvironmentAnimator;
    MeshCollider meshCollider;
    Mesh mesh;

    // Start is called before the first frame update
    private void Start()
    {
        meshCollider = GetComponentInChildren<MeshCollider>();
        mesh = new Mesh();
    }

    private void LateUpdate()
    {
        if (hasBeenTriggered)
        {
            GetComponentInChildren<SkinnedMeshRenderer>().BakeMesh(mesh);
            meshCollider.sharedMesh = mesh;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (hasBeenTriggered)
        {
            timeTillTriggered += Time.deltaTime * Time.deltaTime;
        }
        EnvironmentAnimator.SetFloat("Time", timeTillTriggered);
    }
}
