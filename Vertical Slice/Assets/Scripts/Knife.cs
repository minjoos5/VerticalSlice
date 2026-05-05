using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : Items
{
    public bool _hasKnife = false;

    [SerializeField] Rigidbody _NPCrb;

    [SerializeField] AudioSource _attackSFX;

    public float _power = 10f;


    void Start()
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
            Vector3 _attack = transform.position;
            _NPCrb.AddForce(_attack * _power, ForceMode.Impulse);
            _attackSFX.Play(0);
        }
    }
}
