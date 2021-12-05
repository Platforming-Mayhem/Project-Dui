using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddKeyScript : MonoBehaviour
{
    Animator anim;
    AudioSource audioS;
    public AudioClip collectSFX;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        audioS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void deactivate()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetTrigger("Collected");
            audioS.PlayOneShot(collectSFX);
        }
    }
}
