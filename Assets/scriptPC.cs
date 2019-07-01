using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptPC : MonoBehaviour
{
    public float velocidade;
    public float velRot;
    private Rigidbody rbd;
    public LayerMask mascara;
    private AudioSource som;
    private Quaternion rotOriginal;
    private float rotMX=0;
    public Camera olhos;
    
    // Start is called before the first frame update
    void Start()
    {
        velRot = 40;
        velocidade = 5;
        rbd = GetComponent<Rigidbody>();
        som = GetComponent<AudioSource>();
        
        rotOriginal = transform.localRotation;
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveL = Input.GetAxis("Horizontal");
        float moveF = Input.GetAxis("Vertical");

        rotMX += Input.GetAxis("Mouse X");
        

        Quaternion lado = Quaternion.AngleAxis(rotMX,Vector3.up);
        

        transform.localRotation = rotOriginal * lado ;

        rbd.velocity = transform.TransformDirection(new Vector3(moveL * velocidade, rbd.velocity.y, moveF * velocidade));

        int dir = 0;
        if (Input.GetKey(KeyCode.Q))
            dir = -1;
        else if (Input.GetKey(KeyCode.E))
            dir = 1;

        transform.Rotate(new Vector3(0,dir * velRot * Time.deltaTime,0));

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            som.Play();
            RaycastHit hit;

            if (Physics.Raycast(olhos.transform.position, olhos.transform.forward, out hit, 100, mascara))
            {
                Vector3 forca = transform.forward * 500;
                hit.collider.GetComponent<Rigidbody>().AddForce(forca);
            }
            

        }

    }
}
