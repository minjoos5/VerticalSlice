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
        RaycastHit hit;
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out hit)) {
            Transform objectHit = hit.transform;
            Debug.Log(hit.collider.name);
            // Do something with the object that was hit by the raycast.
        }
    }
}
