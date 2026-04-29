using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Items
{
    public bool _readyToEscape = false;

    public void Start()
    {
        gameObject.SetActive(false);
    }
    public void SpawnDoor()
    {
        Debug.Log("Door is here!");
        if (Locator.Instance._key._gotKey == true)
        {
            Debug.Log("the door is spawned");
            gameObject.SetActive(true);
            _readyToEscape = true;
        }
    }


    public override void InheritUpdate()
    {
        base.InheritUpdate();
        Locator.Instance._clicked.InteractionE_Door();
    }
    public void Escape()
    {
        if (Locator.Instance._key._gotKey == true)
        {
            Locator.Instance._ui.GameWin();
        }
    }

    public override void OnMouseDown()
    {
        Debug.Log("cannot click");
    }

}
