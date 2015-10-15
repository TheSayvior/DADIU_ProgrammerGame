using UnityEngine;
using System.Collections;

public class AIMovement : MonoBehaviour {

    public Transform destination;
    private NavMeshAgent agent;

    void Start () 
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        agent.SetDestination(destination.position);
    }
}

