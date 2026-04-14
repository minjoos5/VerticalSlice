using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    [SerializeField] private float _runSpeed = 10f;
    [SerializeField] private float _mouseSensitivity = 100f;

    private Transform _cameraTransform;
    private float _rotationX = 0f;

    void Start()
    {
        // freeze the cursor in the middle of the screen and hide it
        // instead of the cursor, the crosshair will be used to aim
        _cameraTransform = Camera.main.transform;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Mouse movement
        float _xMouse = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
        float _yMouse = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;

        transform.Rotate(Vector3.up * _xMouse);

        _rotationX -= _yMouse;
        _rotationX = Mathf.Clamp(_rotationX, -90f, 90f);
        _cameraTransform.localRotation = Quaternion.Euler(_rotationX, 0f, 0f);
    
        // WASD movement of player
        float _xInput = Input.GetAxis("Horizontal");
        float _zInput = Input.GetAxis("Vertical");

        Vector3 _playerMovement = transform.right * _xInput + transform.forward * _zInput;
        transform.position += _playerMovement * _speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.Space))
        {
            transform.position += _playerMovement * _runSpeed * Time.deltaTime;
        }
    }

}
