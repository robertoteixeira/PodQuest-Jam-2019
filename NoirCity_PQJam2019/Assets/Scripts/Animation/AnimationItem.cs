using System;
using System.Collections;
using UnityEngine;

public class AnimationItem : MonoBehaviour, IAnimationItem
{
    public bool IsMain;

    public float AnimationLength { get; set; }
    public Action OnBegin { get; set; }
    public Action OnEnd { get; set; }

    private Animation _anim;    

    private void Awake()
    {        
        _anim = GetComponent<Animation>();

        if (_anim == null)
        {
            Debug.Log("Error: Did not find anim!");
        }

        else
        {          
            AnimationLength = _anim.clip.length;            
        }
    }

    public void Begin()
    {        
        _anim.Play();
        StartCoroutine(End(AnimationLength));
    }

    public IEnumerator End(float interval)
    {
        yield return new WaitForSeconds(interval);
        OnEnd?.Invoke();
    }
}
