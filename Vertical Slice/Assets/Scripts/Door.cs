using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Items
{
    public bool _readyToEscape = false;
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

}
