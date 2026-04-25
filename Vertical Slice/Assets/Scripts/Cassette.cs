using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cassette : Items
{
    [SerializeField] GameObject _cassetteItself;

    private bool _isTrueCassette;

    private bool _gotRightOne = false;

    int r = 0;

    override public void OnMouseDown()
    {
        base.OnMouseDown();

        if (_gotRightOne == false)
        {
            r = Random.Range(0,2);
            if (r == 0)
            {
                _isTrueCassette = false;
                Debug.Log("fake tape");
            }
            else
            {
                _gotRightOne = true;
                _isTrueCassette = true;
                Debug.Log("true tape");
            }
        }
        else if (_gotRightOne == true && _isTrueCassette == false)
        {
            Debug.Log("fake tape");
        }
    }
}
