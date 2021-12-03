using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockScript : MonoBehaviour
{
    public Animator lock01;
    public Animator lock02;
    public Animator lock03;
    public Animator door;
    InventoryScript pl;
    // Start is called before the first frame update
    void Start()
    {
        pl = FindObjectOfType<InventoryScript>();
        door.SetTrigger("Lock");
        lock01.SetTrigger("Lock");
        lock02.SetTrigger("Lock");
        lock03.SetTrigger("Lock");

    }

    // Update is called once per frame
    void Update()
    {
        if (pl.ReadKey() == 3)
        {
            lock01.SetTrigger("Unlock");
            door.SetTrigger("Unlock");
        }
        if (pl.ReadKey() == 2)
        {
            lock02.SetTrigger("Unlock");
        }
        if(pl.ReadKey() == 1)
        {
            lock03.SetTrigger("Unlock");
        }
    }
}
