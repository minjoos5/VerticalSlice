using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public bool _gotKey;

    void Start()
    {
        _gotKey = false;
    }
    void OnMouseDown()
    {
        gameObject.SetActive(false);
        _gotKey = true;
        Debug.Log("Got Key");
        Locator.Instance._door.SpawnDoor();
    }
}