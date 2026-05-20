using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Blink : MonoBehaviour
{
    public Animator _animator;

    public float _minTime = 0.5f;

    public float _maxTime = 2.0f;

    public bool _progress = true;

    public void Start()
    {
        StartCoroutine(BlinkTime());
    }

    public void Update()
    {
        if (Locator.Instance._diaManage._gameStart == true)
        {
            _animator.SetBool("isBlinking", false);
        }
    }
    public IEnumerator eyeBlink()
    {
        _animator.SetBool("isBlinking", true);
        yield return new WaitForSeconds (Random.Range(_minTime,_maxTime));
        _animator.SetBool("isBlinking", false);
    }

    public IEnumerator BlinkTime()
    {
        _animator.SetBool("openEye", true);
        for (int i = 0; i <= 5; i++)
        {
            yield return eyeBlink();
        }
    }
}
