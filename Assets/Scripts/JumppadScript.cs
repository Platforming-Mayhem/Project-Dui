using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumppadScript : MonoBehaviour
{
    Animator anim;
    NewPlayerScript playerScript;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        jump = false;
        playerScript = FindObjectOfType<NewPlayerScript>();
    }
    public bool jump;
    float s = 0f;
    // Update is called once per frame
    void Update()
    {
        if (jump)
        {
            s += Time.deltaTime * 9.8f;
            playerScript.rb.velocity = Vector3.Scale(Vector3.one - Vector3.up, playerScript.rb.velocity) + Vector3.up * playerScript.curveEquation(10f, s);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            anim.SetTrigger("Jump");
            jump = true;
        }
    }
}
