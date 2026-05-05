using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    [SerializeField] public Slider _staminaSlider;

    public void UIupdate (float _currentStamina)
    {
        _staminaSlider.value = _currentStamina;
    }
}
