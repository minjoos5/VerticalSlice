using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : Items
{
    public bool _hasKnife = false;

    [SerializeField] Rigidbody _NPCrb;

    [SerializeField] AudioSource _attackSFX;

    [SerializeField] Transform _player;

    [SerializeField] Transform _NPC;

    [SerializeField] Camera _mainCamera;
    public float _power = 300f;

    //public bool _playerAttack = false;


    void Awake()
    {
        //gameObject.SetActive(false);
        _hasKnife = false;
    }

    public override void OnMouseDown()
    {
        _hasKnife = true;
        gameObject.SetActive(false);
    }

    public void AttackwKnife()
    {
        if (_hasKnife == true)
        {
            //(enemyPos - playerPos).normalized * _power
            Vector3 _attack = (_NPC.transform.position - _player.transform.position).normalized;
            _NPCrb.AddForce(_attack * _power, ForceMode.Impulse);
            _attackSFX.Play(0);
        }
    }

    /*public void InteractionE_Knife()
    {
        RaycastHit _hit;
        Ray _ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(_ray, out _hit, 10f) && _hit.collider.gameObject.CompareTag("NPC"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                AttackwKnife();
                _playerAttack = true;
            }
        }
    }*/
}
