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

    [SerializeField] private Animator _animator;
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
        if (_distance >= 4f)
        {
            _currentActivity = NPCstate.Walking;
        }
        else if (_distance < 4f && _distance > 1f)
        {
            _currentActivity = NPCstate.Chasing;
        }
        else if (_distance <= 1f)
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
        agent.speed = 1.5f;
        Debug.Log ("Chasing now");
        _animator.SetBool("isChasing", true);
        _animator.SetBool("isAttacking", false);
        _animator.SetBool("isWalking", false);
    }

    private void AttackAnimation()
    {
        agent.speed = 0.5f;
        Debug.Log ("Attacking now");
        _animator.SetBool("isChasing", false);
        _animator.SetBool("isAttacking", true);
        _animator.SetBool("isWalking", false);
    }
    
    private void WalkAnimation()
    {
        agent.speed = 0.2f;
        Debug.Log ("Walking now");
        _animator.SetBool("isChasing", false);
        _animator.SetBool("isAttacking", false);
        _animator.SetBool("isWalking", true);
    }
}
