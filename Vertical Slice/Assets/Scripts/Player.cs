using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _runSpeed = 10f;
    [SerializeField] private float _mouseSensitivity = 100f;

    [SerializeField] private CapsuleCollider _collider;

    private Transform _cameraTransform;

    private Rigidbody _rb;
    private float _rotationX = 0f;

    private Vector3 _playerMovement;

    public bool _noEnergy;

    public float _staminaDecrease = 5f;

    public float _staminaIncrease = 2f;

    public float _staminaBase = 10f;

    void Start()
    {
        // freeze the cursor in the middle of the screen and hide it
        // instead of the cursor, the crosshair will be used to aim
        _cameraTransform = Camera.main.transform;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _rb = this.GetComponent<Rigidbody>();
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

        //Vector3 _playerMovement = transform.right * _xInput + transform.forward * _zInput;
        //transform.position += _playerMovement * _speed * Time.deltaTime;

        _playerMovement = new Vector3 (Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        isExhausted();
        playerMovement();
    }

    private void playerMovement()
    {
        Vector3 _movement = transform.TransformDirection(_playerMovement) * _speed;
        _rb.velocity = new Vector3 (_movement.x, _rb.velocity.y, _movement.z);

        if (Input.GetKey(KeyCode.Space))
        {
            if (_noEnergy == false)
            {
                _movement = transform.TransformDirection(_playerMovement) * _runSpeed;
                _rb.velocity = new Vector3 (_movement.x, _rb.velocity.y, _movement.z);
                _staminaBase -= _staminaDecrease * Time.deltaTime;
            }
        }
        else
        {
            if (_staminaBase < 10f)
            {
                _staminaBase += _staminaIncrease * Time.deltaTime;
            }
        }
    }

    private void isExhausted ()
    {
        if (_staminaBase == 0)
        {
            _noEnergy = true;
        }
        else if (_staminaBase > 0)
        {
            _noEnergy = false;
        }
    }

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

    private void OnCollisionEnter (Collision collision)
    {
        NPC _npc = collision.gameObject.GetComponent<NPC>();
        if (_npc != null  && Locator.Instance._NPC._isAttacking == true)
        {
            Locator.Instance._ui.GameOver();
        }
    }

}
