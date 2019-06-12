using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptPC : MonoBehaviour
{
    public float velocidade;
    public float velRot;
    private Rigidbody rbd;
    // Start is called before the first frame update
    void Start()
    {
        velRot = 40;
        velocidade = 5;
        rbd = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveL = Input.GetAxis("Horizontal");
        float moveF = Input.GetAxis("Vertical");

       
        rbd.velocity = transform.TransformDirection(new Vector3(moveL * velocidade, rbd.velocity.y, moveF * velocidade));

        int dir = 0;
        if (Input.GetKey(KeyCode.Q))
            dir = -1;
        else if (Input.GetKey(KeyCode.E))
            dir = 1;

        transform.Rotate(new Vector3(0,dir * velRot * Time.deltaTime,0));

    }
}
