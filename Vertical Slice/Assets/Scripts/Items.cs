using System.Collections;
using System.Collections.Generic;
using UnityEngine;


interface Interactable
{
    public void Interact();
}
public class Items : MonoBehaviour
{
    // the list of items: key, cassette tape, cassette tape;
    // the item disappears when the player picks it up
    // maybe interactable with E key?
    // space to run
    [SerializeField] List <GameObject> _location = new List <GameObject> {};
    
    [SerializeField] Transform _playerTransform;

    public float _interact;


    void Start()
    {
        foreach (GameObject _spot in _location)
        {
            _spot.SetActive(true);
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            InteractionE();
            Debug.Log("interacting now");
        }
    }

    public void OnMouseDown()
    {
        Debug.Log("clicked!");
        gameObject.SetActive(false);
    }

    public void InteractionE()
    {
        Ray _ray = new Ray (_playerTransform.position, _playerTransform.forward);
        if (Physics.Raycast(_ray, out RaycastHit _hit, _interact))
        {
            if (_hit.collider.gameObject.TryGetComponent(out Interactable _targetObj))
            {
                _targetObj.Interact();
            }
        }
    }
}
