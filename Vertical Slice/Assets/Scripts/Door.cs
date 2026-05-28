using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class Door : Items
{
    public GameObject _door;
    public GameObject _key;

    public bool _readyToEscape;

    public Transform _playerTrans;



    public void Start()
    {
        //bool _gotKey = (bool)Variables.Scene(_key).Get("_gotKey");
        gameObject.SetActive(false);
    }

    public void Update()
    {
        _readyToEscape = (bool)Variables.Scene(_door).Get("_readyToEscape");
    }

    public void Escape()
    {
        if (_readyToEscape == true)
        {
            //Locator.Instance._ui.GameWin();
            _playerTrans.position = new Vector3 (28f, 2f, -9f);
            Locator.Instance._diaManage._l2Start = true;
        }
    }

    public override void OnMouseDown()
    {
        Debug.Log("cannot click");
    }

    /*public void SpawnDoor()
    {
        bool _gotKey = (bool)Variables.Scene(_key).Get("_gotKey");
        Debug.Log("Door is here!");

        if (_gotKey == true)
        {
            Debug.Log("the door is spawned");
            Debug.Log("current key val: " + _gotKey);
            gameObject.SetActive(true);
            _readyToEscape = true;
        }
    }*/
}
