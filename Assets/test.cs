using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

    UnityEngine.AI.NavMeshAgent agent;
    public Transform t;
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }


    public void mover(Vector3 pos)
    {
        agent.destination = pos;
    }

}
