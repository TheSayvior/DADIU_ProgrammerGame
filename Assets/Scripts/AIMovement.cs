using UnityEngine;
using System.Collections;

public class AIMovement : MonoBehaviour {

    //public Transform destination;
    GameObject player;
    private NavMeshAgent agent;

    void Start () 
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        agent.SetDestination(player.transform.position);
    }
}

