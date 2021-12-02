using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTargeting : MonoBehaviour
{
    Animator anim;
    NewPlayerScript player;
    public GameObject KeyBase;
    GameObject insta;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInParent<Animator>();
        player = FindObjectOfType<NewPlayerScript>();
    }
    float time = 0f;
    // Update is called once per frame
    void Update()
    {
        if(insta != null)
        {
            time += Time.deltaTime;
            insta.transform.position += Vector3.down * player.curveEquation(1f, time);
        }
    }

    public void spawn()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Scene (1)"))
        {
            insta = Instantiate(KeyBase, player.transform.position + Vector3.up * 20f, Quaternion.identity);
        }
    }
}
