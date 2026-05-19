using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    public Animator _animator;

    public float _minTime = 0.5f;

    public float _maxTime = 2.0f;

    public bool _progress = true;

    public void Start()
    {
        
        StartCoroutine(eyeBlink());
    }

    public IEnumerator eyeBlink()
    {
        _animator.SetBool("isBlinking", false);
        yield return new WaitForSeconds (Random.Range(_minTime,_maxTime));
        _animator.SetBool("isBlinking", true);
    }

    public IEnumerator BlinkTime()
    {
        for (int i = 0; i <= 10; i++)
        {
            yield return eyeBlink();
        }
    }
}
