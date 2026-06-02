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

    //[SerializeField] public AudioSource _knifesfx;

    //[SerializeField] public AudioSource _walkingsfx;

    //[SerializeField] public AudioSource _runningsfx;


    [SerializeField] public Player _playerClass;
    public GameObject _playerPos;
    public GameObject _NPCPos;
    private NavMeshAgent agent;
    public NPCstate _currentActivity;
    public float _distance;
    public bool _isAttacking = false;

    public bool _isDetected = false;

    public SkinnedMeshRenderer _rendererJoint;

    public SkinnedMeshRenderer _rendererSurface;

    public GameObject _joint;

    public GameObject _surface;

    Color _originColJoint;

    Color _originColSurface;

    //public bool _playerAttackNPC;

    public void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        gameObject.SetActive(false);
        _rendererJoint = _joint.GetComponent<SkinnedMeshRenderer>();
        _rendererSurface = _surface.GetComponent<SkinnedMeshRenderer>();
        _originColJoint = _rendererJoint.material.color;
        _originColSurface = _rendererSurface.material.color;
    }


    public void hitDamage()
    {
        StartCoroutine(hitFlash());
    }

    public IEnumerator hitFlash()
    {
        _rendererJoint.material.color = Color.red;
        _rendererSurface.material.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        _rendererJoint.material.color = _originColJoint;
        _rendererSurface.material.color = _originColSurface;
    }
    void Update()
    {
        agent.SetDestination(target.position);
        SightDetection();
        //CalculateDistance();
        //UpdateState();
        //UpdateAnimation();
        //_playerAttackNPC = _playerClass._playerAttack;
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

            if (_hit.collider.gameObject.CompareTag("Player"))// && _warning.isPlaying == false)
            {
                _isDetected = true;
                if (_warning.isPlaying == false)
                {
                    _warning.Play();
                }
                //_warning.Play();
                //Debug.Log("Sound is playing");
                
                //Debug.Log("Hitting Now");
            }
            else
            {
                _warning.Stop();
                _isDetected = false;
                //Debug.Log("No");
            }
            
        }
    }

    public void ChaseAnimation()
    {
        //agent.speed = 1.5f;
        agent.speed = 0.5f;
        //Debug.Log ("Chasing now");
        _animator.SetBool("isChasing", true);
        _animator.SetBool("isAttacking", false);
        _animator.SetBool("isWalking", false);
        _animator.SetBool("Hit", false);
        _isAttacking = false;

        

        /*if (_animator.GetBool("isChasing") == true)
        {
            _runningsfx.Play();
        }
        else
        {
            _runningsfx.Stop();
        }*/
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
        _animator.SetBool("Hit", false);
        _isAttacking = true;

        /*if (_animator.GetBool("isAttacking") == true)
        {
            _knifesfx.Play();
        }
        else
        {
            _knifesfx.Stop();
        }*/
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
        _animator.SetBool("Hit", false);
        _isAttacking = false;

        /*if (_animator.GetBool("isWalking") == true)
        {
            _walkingsfx.Play();
        }
        else
        {
            _walkingsfx.Stop();
        }*/
        
    }

    public void HitAnimation()
    {
        //agent.speed = 0.2f;
        //agent.speed = 0.05f;
        //Debug.Log ("Walking now");
        _animator.SetBool("isChasing", false);
        _animator.SetBool("isAttacking", false);
        _animator.SetBool("isWalking", false);
        _animator.SetBool("Hit", true);
        _isAttacking = false;

        Debug.Log ("Hit animation is playing");
    }
    // declared in graph

    
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

}
