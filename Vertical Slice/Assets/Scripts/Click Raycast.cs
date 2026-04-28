using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class ClickRaycast : MonoBehaviour
{
    [SerializeField] Camera _mainCamera;

    public bool _itemDetected = false;

    public virtual void InteractionE()
    {
        RaycastHit _hit;
        Ray _ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(_ray, out _hit) && _hit.collider.gameObject.CompareTag("InteractableItem"))
        {
            
            Transform objectHit = _hit.transform;
            Locator.Instance._ui.EInteractDisplay();

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (Locator.Instance._door._readyToEscape == true)
                //Debug.Log("hit E on " + gameObject.name);
                Locator.Instance._ui._EToInteract.gameObject.SetActive(false);
                gameObject.SetActive(false);
            }
            
            //Debug.Log(_hit.collider.name);
            //Debug.Log("itworksfinalllyyylylylyly");
            //Locator.Instance._ui._EToInteract.gameObject.SetActive(false);
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
}
