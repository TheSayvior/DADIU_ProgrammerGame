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
        if (!Input.anyKey)
        {
            agent.Stop();
            return;
        }
        else
        {
            agent.Resume();
        }
        agent.SetDestination(player.transform.position);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player") {
            Destroy(player);
        }
    }
}

