using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;
using Unity.VisualScripting;

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

    [SerializeField] public GameObject _message;

    [SerializeField] public GameObject _head;

    [SerializeField] public AudioSource _warning;
    public GameObject _playerPos;
    public GameObject _NPCPos;
    private NavMeshAgent agent;
    public NPCstate _currentActivity;
    public float _distance;
    public bool _isAttacking = false;

    public void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        //gameObject.SetActive(false);

    }

    public void Start()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
        SightDetection();
        //CalculateDistance();
        //UpdateState();
        //UpdateAnimation();
    }

    public void CalculateDistance()
    {
        _distance = Vector3.Distance(_playerPos.transform.position, _NPCPos.transform.position);
        //Debug.Log(_distance);
    }

    public void SightDetection()
    {
        Transform _headPos = _head.transform;
        
        RaycastHit _hit;

        if (Physics.Raycast(_headPos.position, transform.TransformDirection(Vector3.forward), out _hit, 10f))
        {
            Transform objectHit = _hit.transform;
            Debug.DrawRay(_headPos.position, transform.TransformDirection(Vector3.forward) * _hit.distance, Color.yellow);

            if (_hit.collider.gameObject.CompareTag("Player") && _warning.isPlaying == false)
            {
                _warning.Play();
                Debug.Log("Sound is playing");
            }
            else
            {
                //_warning.Stop();
            }
            
        }
    }

    /*public void UpdateState()
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
    }*/

    /*public void UpdateAnimation()
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
    }*/

    public void ChaseAnimation()
    {
        //agent.speed = 1.5f;
        agent.speed = 0.5f;
        //Debug.Log ("Chasing now");
        _animator.SetBool("isChasing", true);
        _animator.SetBool("isAttacking", false);
        _animator.SetBool("isWalking", false);
        _isAttacking = false;
    }
    // declared in graph

    public void AttackAnimation()
    {
        //agent.speed = 0.5f;
        agent.speed = 1.0f;
        //Debug.Log ("Attacking now");
        _animator.SetBool("isChasing", false);
        _animator.SetBool("isAttacking", true);
        _animator.SetBool("isWalking", false);
        _isAttacking = true;
    }
    // declared in graph
    
    public void WalkAnimation()
    {
        //agent.speed = 0.2f;
        agent.speed = 0.05f;
        //Debug.Log ("Walking now");
        _animator.SetBool("isChasing", false);
        _animator.SetBool("isAttacking", false);
        _animator.SetBool("isWalking", true);
        _isAttacking = false;
    }
    // declared in graph
}
