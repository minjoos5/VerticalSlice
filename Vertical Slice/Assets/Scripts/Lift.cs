using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class Lift : MonoBehaviour
{

    public GameObject _lift;
    public GameObject _crowbar;

    public bool _readyToEscapeL2;

    public Transform _playerTrans;

    public void Start()
    {
        _readyToEscapeL2  = false;
    }

    public void Update()
    {
        _readyToEscapeL2 = (bool)Variables.Scene(_crowbar).Get("_gotCB");
    }

    public void EscapeL2()
    {
        if (_readyToEscapeL2 == true)
        {
            Locator.Instance._ui.GameWin();
        }
    }
}
