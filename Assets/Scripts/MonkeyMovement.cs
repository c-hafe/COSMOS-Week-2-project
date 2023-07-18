using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyMovement : MonoBehaviour
{

    UnityEngine.AI.NavMeshAgent agent;
    GameObject goal;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        goal = GameObject.Find("Goal");
        agent.SetDestination(goal.transform.position);
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }

 
}
