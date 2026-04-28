using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cassette : Items
{

    public bool _isTrueCassette;

    public static bool _gotRightOne = false;

    int r = 0;

    void Awake()
    {
        _gotRightOne = false;
        _isTrueCassette = false;
    }

    void Start()
    {
        gameObject.SetActive(true);
    }

    public override void InheritUpdate()
    {
        base.InheritUpdate();
    }

    override public void OnMouseDown()
    {
        base.OnMouseDown();

        if (_gotRightOne == true)
        {
            _isTrueCassette = false;
            Debug.Log("fake tape");
        }
        else if (_gotRightOne == false)
        {
            r = Random.Range(0,2);
            if (r == 0)
            {
                _isTrueCassette = false;
                Debug.Log("fake tape");
            }
            else if (r == 1)
            {
                _gotRightOne = true;
                _isTrueCassette = true;
                Debug.Log("true tape");
            }
        }
    }
}
