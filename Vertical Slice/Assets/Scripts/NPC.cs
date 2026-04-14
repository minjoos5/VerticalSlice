using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum NPCstate
    {
        Walking,
        Chasing,
        Attacking
    }

public class NPC : MonoBehaviour
{
    [SerializeField] private Transform target;
    private NavMeshAgent agent;

    private NPCstate _currentActivity;
    private void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.SetDestination(target.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
