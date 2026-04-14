using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    // the list of items: key, cassette tape, cassette tape;
    // the item disappears when the player picks it up
    // maybe interactable with E key?
    // shift to run
    void Start()
    {
        
    }

    
    public void itemClicked()
    {
        if (Locator.Instance._clicked._itemDetected == true)
        {
            GameObject.SetActive(false);
        }
    }
}
