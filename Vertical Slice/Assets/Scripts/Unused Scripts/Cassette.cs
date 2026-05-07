using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
/*
public class Cassette : MonoBehaviour
{
    [SerializeField] public List <GameObject> _cassLocation = new List <GameObject> {};

    [SerializeField] GameObject _cassPrefab;

    public bool _isTrueCassette;

    public static bool _gotRightOne = false;

    int r = 0;

    void Awake()
    {
        _gotRightOne = false;
        _isTrueCassette = false; 

        CassettePrefab();
    }

    void Start()
    {
        gameObject.SetActive(true);
    }

    public void CassettePrefab()
    {
        for (int p = 0; p < 3; p++)
        {
            GameObject _threeCass = Instantiate(_cassPrefab, _cassLocation[p].transform.position, Quaternion.identity);     
        }
    }

    public void Update()
    {
        Locator.Instance._cassPl.InteractionE_Cassette();
    }

    public void OnMouseDown()
    {
        if (_gotRightOne == true)
        {
            _isTrueCassette = false;
            Debug.Log("fake tape");
        }
        else if (_gotRightOne == false)
        {
            r = Random.Range(0,2);
            if (r == 0)
            {
                _isTrueCassette = false;
                Debug.Log("fake tape");
            }
            else if (r == 1)
            {
                _gotRightOne = true;
                _isTrueCassette = true;
                Debug.Log("true tape");
            }
        }

        gameObject.SetActive(false);
    }
}
*/