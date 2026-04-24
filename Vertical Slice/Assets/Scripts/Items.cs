using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    // the list of items: key, cassette tape, cassette tape;
    // the item disappears when the player picks it up
    // maybe interactable with E key?
    // space to run

    [SerializeField] List <GameObject> _location = new List <GameObject> {};
    void Start()
    {
        foreach (GameObject _spot in _location)
        {
            _spot.SetActive(true);
        }
    }

    
    public void OnMouseDown()
    {
        Debug.Log("clicked!");
        gameObject.SetActive(false);
    }

    public void Interaction()
    {
        
    }
}
