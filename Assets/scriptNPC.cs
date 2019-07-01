using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class scriptNPC : MonoBehaviour
{
    public GameObject pc;
    private NavMeshAgent agente;
    public GameObject[] waypoints = new GameObject[4];
    private int index = 0;
    public float maxDist = 1;
    private bool perseguindo = false;
    // Start is called before the first frame update
    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        proximo();
    }

    void proximo()
    {
        agente.destination = waypoints[index++].transform.position;
        if (index >= waypoints.Length)
            index = 0;

    }

    // Update is called once per frame
    void Update()
    {
        //agente.destination = pc.transform.position;
        //Se a distância entre o NPC e o waypoint atual for menor que 1
        //então, vá para o próximo destino
        if (perseguindo || Vector3.Distance(transform.position, pc.transform.position) <= 5)
        {
            perseguindo = true;
            agente.destination = pc.transform.position;
        }else if (Vector3.Distance(transform.position, agente.destination) <= maxDist)
            proximo();
        
    }
}
