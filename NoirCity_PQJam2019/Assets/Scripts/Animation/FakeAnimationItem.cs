using System;
using System.Collections;
using UnityEngine;

public class FakeAnimationItem : MonoBehaviour, IAnimationItem
{
    public float IntervalInSeconds;

    public Action OnBegin { get; set; }
    public Action OnEnd { get; set; }
    public float AnimationLength { get; set; }

    public void Begin()
    {
        gameObject.SetActive(true);
        AnimationLength = IntervalInSeconds;
        StartCoroutine(End(AnimationLength));
    }

    public IEnumerator End(float interval)
    {        
        yield return new WaitForSecondsRealtime(interval);
        OnEnd?.Invoke();
        gameObject.SetActive(false);
    }
    
}
