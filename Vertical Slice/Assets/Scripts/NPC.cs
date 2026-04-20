using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
    public GameObject _playerPos;
    public GameObject _NPCPos;
    private NavMeshAgent agent;
    private NPCstate _currentActivity;
    private float _distance;
    private void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
        CalculateDistance();
        UpdateState();
        UpdateAnimation();
    }

    private void CalculateDistance()
    {
        _distance = Vector3.Distance(_playerPos.transform.position, _NPCPos.transform.position);
        Debug.Log(_distance);
    }

    private void UpdateState()
    {
        if (_distance > 30f)
        {
            _currentActivity = NPCstate.Walking;
        }
        else if (_distance <= 20f)
        {
            _currentActivity = NPCstate.Chasing;
        }
        else if (_distance <= 7f)
        {
            _currentActivity = NPCstate.Attacking;
        }
    }

    private void UpdateAnimation()
    {
        switch (_currentActivity)
        {
            case NPCstate.Chasing:
            ChaseAnimation();
            break;

            case NPCstate.Attacking:
            AttackAnimation();
            break;

            case NPCstate.Walking:
            WalkAnimation();
            break;
        }
    }

    private void ChaseAnimation()
    {
        agent.speed = 2.0f;
        Debug.Log ("Chasing now");
    }

    private void AttackAnimation()
    {
        agent.speed = 3.0f;
        Debug.Log ("Attacking now");
    }
    
    private void WalkAnimation()
    {
        agent.speed = 0.5f;
        Debug.Log ("Walking now");
    }
}
