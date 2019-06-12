using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptPorta : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
            anim.SetBool("abrir", true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag=="Player")
            anim.SetBool("abrir", false);
    }
}
