using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class Crowbar : MonoBehaviour
{
    public Animator _animator;

    public bool _hasCB = false;

    [SerializeField] Rigidbody _NPCL2rb;

    [SerializeField] AudioSource _attackSFX;

    [SerializeField] Transform _player;

    [SerializeField] Transform _NPCL2;

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


    public void AttackwKnife()
    {
        if (_hasCB == true)
        {
            Vector3 _attack = (_NPCL2.transform.position - _player.transform.position).normalized;
            _NPCL2rb.AddForce(_attack * _power, ForceMode.Impulse);
            _attackSFX.Play(0);
        }
    }
    public void IdleAnimation()
    {
        _animator.SetBool("isUsing", false);
    }
    public void UsingAnimation()
    {
        _animator.SetBool("isUsing", true);
    }


}
