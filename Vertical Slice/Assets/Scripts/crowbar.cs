using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class Crowbar : MonoBehaviour
{
    //public Animator _animator;

    public bool _hasCB = false;

    [SerializeField] Rigidbody _NPCL2rb;

    [SerializeField] AudioSource _attackSFX;

    [SerializeField] Transform _player;

    [SerializeField] Transform _NPCL2trans;

    [SerializeField] GameObject _NPCL2;

    [SerializeField] Camera _mainCamera;

    [SerializeField] GameObject _handCB;
    public float _power = 300f;

    //public bool _playerAttack = false;


    void Awake()
    {
        //gameObject.SetActive(false);
        _hasCB = false;
    }

    void Update()
    {
        _hasCB = (bool)Variables.Scene(_handCB).Get("_gotCB");
    }

    public void AttackwCB()
    {
        if (_hasCB == true)
        {
            Vector3 _attack = (_NPCL2.transform.position - _player.transform.position).normalized;
            _NPCL2rb.AddForce(_attack * _power, ForceMode.Impulse);
            _attackSFX.Play(0);
        }
    }

    /*public void UseCrowbar()
    {
        RaycastHit _hit;
        Ray _ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(_ray, out _hit, 5f) && _hit.collider.gameObject.CompareTag("NPC") && Locator.Instance._cb._hasCB == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Variables.Scene(_NPCL2).Set("_playerAttack", true);
                AttackwCB();
            }
        }

        /*if (Physics.Raycast(_ray, out _hit, 5f) && _hit.collider.gameObject.CompareTag("Lift") && Locator.Instance._cb._hasCB == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                AttackwCB();
            }
        }
    }


    
    /*public void IdleAnimation()
    {
        _animator.SetBool("isUsing", false);
    }
    public void UsingAnimation()
    {
        _animator.SetBool("isUsing", true);
    }*/
}
