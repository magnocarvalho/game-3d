using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptEixo : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            anim.SetBool("abrir", true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            anim.SetBool("abrir", false);
    }
}
