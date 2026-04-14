using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class ClickRaycast : MonoBehaviour
{
    [SerializeField] Camera _mainCamera;

    public bool _itemDetected = false;
    void Update()
    {
        Vector3 _cursorPos = Input.mousePosition;

        Ray _clickDetect = _mainCamera.ScreenPointToRay(_cursorPos);

        RaycastHit _raycastHit;

        _itemDetected = Physics.Raycast (_clickDetect, out _raycastHit);

        //Locator.Instance._items.OnMouseDown();
    }
}
