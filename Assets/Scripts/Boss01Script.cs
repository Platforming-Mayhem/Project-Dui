using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss01Script : MonoBehaviour
{
    bool begin;
    public int Heath = 3;
    public Animator anim;
    public GameObject hurtParticle;
    public GameObject Key;
    public GameObject KeyPickup;
    public GameObject Exit;
    public float speed = 1f;
    BoxCollider box;
    Rigidbody rb;
    [HideInInspector]
    public Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        begin = false;
        anim.enabled = false;
        box = Key.GetComponent<BoxCollider>();
        rb = GetComponentInParent<Rigidbody>();
        Exit.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (begin)
        {
            anim.enabled = true;
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Scene"))
            {
                transform.position += dir * Time.deltaTime * speed;
                box.enabled = false;
            }
            else if(anim.GetCurrentAnimatorStateInfo(0).IsName("Scene (1)"))
            {
                box.enabled = true;
            }
        }
        if(Heath <= 0f)
        {
            Instantiate(KeyPickup, transform.position, Quaternion.identity);
            DestroyImmediate(gameObject);
        }
    }

    public void RemoveHealth()
    {
        Heath -= 1;
        Instantiate(hurtParticle, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            begin = true;
        }
    }

    private void OnDestroy()
    {
        FindObjectOfType<CameraScript>().cameraTypes = CameraScript.CameraTypes.mouseControl;
        Exit.SetActive(true);
    }
}
