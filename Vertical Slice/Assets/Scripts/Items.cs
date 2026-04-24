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

    [SerializeField] List <GameObject> _items = new List <GameObject> {};
    
    [SerializeField] Transform _playerTransform;

    private List <int> _temp = new List <int> {};

    public float _interact;


    int r = 0;



    void Awake()
    {
        foreach (GameObject _spot in _location)
        {
            _spot.SetActive(true);
        }

        foreach (GameObject _spot in _items)
        {
            _spot.SetActive(false);
        }

    }
    void Start()
    {

        for (int i = 0; i < _location.Count; i++)
        {
            r = Random.Range(0, _location.Count - 1);
            _items[i].transform.position = _location[r].transform.position;
            _location.RemoveAt(r);
        }
    }

    public void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.E))
        {
            InteractionE();
            Debug.Log("interacting now");
        }*/


    }

    public void OnMouseDown()
    {
        Debug.Log("clicked!");
        gameObject.SetActive(false);
    }

    /*public void InteractionE()
    {
        Ray _ray = new Ray (_playerTransform.position, _playerTransform.forward);
        if (Physics.Raycast(_ray, out RaycastHit _hit, _interact))
        {
            if (_hit.collider.gameObject.TryGetComponent(out Interactable _targetObj))
            {
                _targetObj.Interact();
            }
        }
    }*/
}
