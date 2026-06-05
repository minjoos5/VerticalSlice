using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _runSpeed = 10f;
    [SerializeField] private float _mouseSensitivity = 40f;

    [SerializeField] private CapsuleCollider _collider;

    private Transform _cameraTransform;

    public Camera _mainCamera;

    private Rigidbody _rb;
    private float _rotationX = 0f;

    private Vector3 _playerMovement;

    public bool _noEnergy;

    public float _staminaDecrease = 5f;

    public float _staminaIncrease = 2f;

    public float _staminaBase;

    public float _maxStamina = 15f;
    public float _minStamina = 0.1f;

    public bool _itemDetected = false;
    public GameObject _trueTapeObj;

    private float _maxDistance = 1.0f;

    public GameObject _npcObj;

    public GameObject _npcl2Obj;

    public GameObject _key;

    public GameObject _handKnife;
    
    public GameObject _handCB;

    public bool _tired = false;

    public float _slowSpeed;

    public bool _keyActive;

    public bool _gotKey;
    

    void Start()
    {
        // freeze the cursor in the middle of the screen and hide it
        // instead of the cursor, the crosshair will be used to aim
        _cameraTransform = Camera.main.transform;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _rb = this.GetComponent<Rigidbody>();
        _itemDetected = false;
        _keyActive = false;
        _gotKey = false;
    }
        
    void Update()
    {
        // Mouse movement
        float _xMouse = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
        float _yMouse = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;

        transform.Rotate(Vector3.up * _xMouse);

        _rotationX -= _yMouse;
        _rotationX = Mathf.Clamp(_rotationX, -100f, 100f);
        _cameraTransform.localRotation = Quaternion.Euler(_rotationX, 0f, 0f);
    
        // WASD movement of player
        float _xInput = Input.GetAxis("Horizontal");
        float _zInput = Input.GetAxis("Vertical");

        _playerMovement = new Vector3 (Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        playerMovement();

        KeySpawn();

        InteractionE_Cassette();
        InteractionE_Door();
        InteractionE_Lift();
        InteractionE_Knife();
        InteractionE_CB();
        InteractionE_Inst();
        Interaction_click();
        //Debug.Log((bool)Variables.Scene(_npcObj).Get("_playerAttack"));
    }

    private void playerMovement()
    {
        Locator.Instance._stamina.UIupdate(_staminaBase, _maxStamina);
        Vector3 _movement;
        _staminaBase = Mathf.Clamp(_staminaBase, _minStamina, _maxStamina);
        
        //_rb.velocity = new Vector3 (_movement.x, _rb.velocity.y, _movement.z);

        if (Input.GetKey(KeyCode.LeftShift) && _staminaBase > _maxStamina * 0.5f)
        {
            _movement = transform.TransformDirection(_playerMovement) * _runSpeed;
            _rb.velocity = new Vector3 (_movement.x, _rb.velocity.y, _movement.z);
            _staminaBase -= _staminaDecrease * Time.deltaTime;
            //Debug.Log("current speed: " + _runSpeed);
        }
        else if (Input.GetKey(KeyCode.LeftShift) && _staminaBase <= _maxStamina * 0.1f)
        {
            _movement = transform.TransformDirection(_playerMovement) * _slowSpeed;
            _rb.velocity = new Vector3 (_movement.x, _rb.velocity.y, _movement.z);
            _staminaBase -= _staminaDecrease * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.LeftShift) && _staminaBase <= _maxStamina * 0.5f)
        {
            _movement = transform.TransformDirection(_playerMovement) * _runSpeed;
            _rb.velocity = new Vector3 (_movement.x, _rb.velocity.y, _movement.z);
            _staminaBase -= _staminaDecrease * Time.deltaTime;
            //Debug.Log("current speed: " + _speed);
        }
        else
        {
            _movement = transform.TransformDirection(_playerMovement) * _speed;
            _rb.velocity = new Vector3 (_movement.x, _rb.velocity.y, _movement.z);
            _staminaBase += _staminaIncrease * Time.deltaTime;
        }
    }

    public void KeySpawn()
    {
        _keyActive = Locator.Instance._ui._checkMap;
        //(bool)Variables.Scene(_key).Get("_correctTape");
        _gotKey = (bool)Variables.Scene(_key).Get("_gotKey");
        //Debug.Log("_keyActive: " + _keyActive);

        if (_keyActive == true  && _gotKey == true)
        {
            _key.SetActive(false);
        }
        else if (_keyActive == true)
        {
            _key.SetActive(true);
        }
    }

    public void Interaction_click()
    {
        RaycastHit _hit;
        Ray _ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(_ray, out _hit, 5.0f) && _hit.collider.gameObject.CompareTag("Item"))
        {
            Locator.Instance._ui._clickToInteract.SetActive(true);
        }
        else
        {
            Locator.Instance._ui._clickToInteract.SetActive(false);
        }
    }

    public void InteractionE_Cassette()
    {
        RaycastHit _hit;
        Ray _ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        bool _checkTape = (bool)Variables.Scene(_trueTapeObj).Get("_correctTape");
        bool _pickedTape = (bool)Variables.Scene(_trueTapeObj).Get("_pickedTape");
        //bool _checkError = (bool)Variables.Object(_falseTapeObj).Get("_falseTape");
        
        if (Physics.Raycast(_ray, out _hit, _maxDistance) && _hit.collider.gameObject.CompareTag("CassettePlayer"))
        {   
            Transform objectHit = _hit.transform;
            //Locator.Instance._ui._EToInteract.SetActive(true);
            _itemDetected = true;

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (_checkTape == true)
                {
                    //Debug.Log("problem with the logic.");
                    Locator.Instance._ui.MapDisplay();
                }
                else if (_pickedTape == true)
                {
                    Locator.Instance._ui.ShowGlitchDisplay();
                }
                else
                {
                    Locator.Instance._ui.ShowEmptyDisplay();
                }
            }
        }
    }


    public void InteractionE_Door()
    {
        RaycastHit _hit;
        Ray _ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(_ray, out _hit, _maxDistance) && _hit.collider.gameObject.CompareTag("Door"))
        {
            Transform objectHit = _hit.transform;
            //Locator.Instance._ui._EToInteract.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                //Debug.Log("hit E on " + gameObject.name);
                //Locator.Instance._ui._EToInteract.SetActive(false);
                Locator.Instance._door.Escape();
                _handKnife.SetActive(false);
                //_npcl2Obj.SetActive(true);
            }
            
            
        }
    }

    public void InteractionE_Lift()
    {
        RaycastHit _hit;
        Ray _ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(_ray, out _hit, _maxDistance) && _hit.collider.gameObject.CompareTag("Lift"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Locator.Instance._lift.EscapeL2();
            }
            
            
        }
    }

    public void InteractionE_Knife()
    {
        RaycastHit _hit;
        Ray _ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(_ray, out _hit, 5f) && _hit.collider.gameObject.CompareTag("NPC") && Locator.Instance._knife._hasKnife == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Variables.Scene(_npcObj).Set("_playerAttack", true);
                Locator.Instance._knife.AttackwKnife();
            }
        }
    }

    public void InteractionE_CB()
    {
        RaycastHit _hit;
        Ray _ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(_ray, out _hit, 5f) && _hit.collider.gameObject.CompareTag("NPC") && Locator.Instance._cb._hasCB == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Variables.Scene(_npcl2Obj).Set("_playerAttackL2", true);
                Locator.Instance._cb.AttackwCB();
            }
        }
    }

    public void InteractionE_Inst()
    {
        RaycastHit _hit;
        Ray _ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        
        
        if (Physics.Raycast(_ray, out _hit, _maxDistance))
        {
            //Debug.DrawRay(_mainCamera.transform.position, transform.TransformDirection(Vector3.forward) * _hit.distance, Color.red);

            if (_hit.collider.gameObject.CompareTag("Door") || _hit.collider.gameObject.CompareTag("CassettePlayer") || _hit.collider.gameObject.CompareTag("Lift") || _hit.collider.gameObject.CompareTag("CB"))
            {
                Locator.Instance._ui._EToInteract.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Locator.Instance._ui._EToInteract.SetActive(false);
                }
            }
        }
        else
        {
            Locator.Instance._ui._EToInteract.SetActive(false);
        }
    }
    
    private void OnCollisionEnter (Collision collision)
    {
        NPC _npc = collision.gameObject.GetComponent<NPC>();
        if (_npc != null  && Locator.Instance._NPC._isAttacking == true)
        {
            Locator.Instance._ui.GameOver();
        }

        NPCL2 _npcL2 = collision.gameObject.GetComponent<NPCL2>();
        if (_npcL2 != null  && Locator.Instance._NPCL2._isAttacking == true)
        {
            Locator.Instance._ui.GameOver();
        }
    }

    /*private void isExhausted (float _currentStamina)
    {
        if (_currentStamina == 0)
        {
            _noEnergy = true;
        }
        else if (_currentStamina > 0)
        {
            _noEnergy = false;
        }
    }*/

    /*private void playerMovement()
    {
        Vector3 _movement = transform.TransformDirection(_playerMovement) * _speed;
        _rb.velocity = new Vector3 (_movement.x, _rb.velocity.y, _movement.z);

        if (Input.GetKey(KeyCode.Space))
        {
            _movement = transform.TransformDirection(_playerMovement) * _runSpeed;
            _rb.velocity = new Vector3 (_movement.x, _rb.velocity.y, _movement.z);
        }
    }*/

    
        //Vector3 _playerMovement = transform.right * _xInput + transform.forward * _zInput;
        //transform.position += _playerMovement * _speed * Time.deltaTime;

        //isExhausted(_staminaBase);
        // check to see if X or Y axis of _playerMovement is non-0 before calling playerMovement()
}
