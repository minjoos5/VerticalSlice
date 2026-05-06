using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    [SerializeField] public Slider _staminaSlider;

    public void UIupdate (float _currentStamina, float _maximum)
    {
        _staminaSlider.value = _currentStamina / _maximum;
        //Debug.LogFormat("current: {0}, max: {1}, percent: {2}", _currentStamina, _maximum, _staminaSlider.value);
    }
}
