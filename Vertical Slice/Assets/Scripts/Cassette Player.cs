using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CassettePlayer : Items
{
    public Camera _mainCamera;

    public GameObject _cassetteTape;
    public override void OnMouseDown()
    {
        Debug.Log("cannot click");
    }

    public void InteractionE_Cassette()
    {
        RaycastHit _hit;
        Ray _ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(_ray, out _hit) && _hit.collider.gameObject)
        {   
            // get components is required

            bool _trueCassette = _cassetteTape.GetComponent<Cassette>()._isTrueCassette;

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("E is pressed");
                Debug.Log("Current cassette " + _trueCassette);
                if (_trueCassette == true)
                {
                    Locator.Instance._ui.MapDisplay();
                    Debug.Log("UI triggered");
                }
            }
        }
    }
}
