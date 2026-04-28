using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


/*interface Interactable
{
    public void Interact();
}*/
public class Items : MonoBehaviour
{
    // the list of items: key, cassette tape, cassette tape;
    // the item disappears when the player picks it up
    // maybe interactable with E key?
    // space to run
    [SerializeField] List <GameObject> _location = new List <GameObject> {};
    [SerializeField] List <GameObject> _items = new List <GameObject> {};
    //[SerializeField] 
    public Transform _playerTransform;
    public Camera _camera;
    [SerializeField] GameObject _cassPrefab;
    public List <GameObject> _temp = new List <GameObject> {};

    public float _interact = 10.0f;

    void Awake()
    {
        _playerTransform = GameObject.Find("Player Capsule").transform;
        
        CassettePrefab();

        foreach (GameObject _spot in _location)
        {
            _spot.SetActive(true);
        }

        foreach (GameObject _spot in _items)
        {
            _spot.SetActive(false);
        }

        _temp = _location.OrderBy( x => Random.value ).ToList( );
        for (int i = 0; i < _location.Count; i++)
        {
            _items[i].transform.position = _temp[i].transform.position;
            //_items[i].SetActive(true);
        }
    }

    public void Update()
    {
        InheritUpdate();
    }

    public virtual void InheritUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            InteractionE();
        }
    }

    public virtual void OnMouseDown()
    {
        Debug.Log("clicked!");
        gameObject.SetActive(false);
    }

    public void InteractionE()
    {
        RaycastHit _hit;
        Ray _ray = _camera.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(_ray, out _hit) && _hit.collider.gameObject.CompareTag("Item"))
        {
            Transform objectHit = _hit.transform;
            gameObject.SetActive(false);
            //Debug.Log(_hit.collider.name);
            Debug.Log("itworksfinalllyyylylylyly");
        }

        /*Ray _ray = _camera.ViewportPointToRay(Input.mousePosition);
        RaycastHit _hit;

        if (Physics.Raycast(_ray, out _hit, _interact)) /*&& _hit.collider.gameObject.CompareTag("Item")
        {
            Debug.Log("check for ray");
            if (_hit.collider.gameObject.TryGetComponent(out Interactable _targetObj))
            {
                _targetObj.Interact();
                Debug.Log("interacting now");
            }
        }*/
    }

    void CassettePrefab()
    {
        for (int p = 0; p < 3; p++)
        {
            GameObject _threeCass = Instantiate(_cassPrefab, new Vector3(0,0,0), Quaternion.identity);
            _items.Add(_threeCass);
        }

        int r = Random.Range(0, 3);
    }
}
