using System;
using System.Collections;
using System.Linq;
using UnityEngine;

public class AnimationItem : MonoBehaviour, IAnimationItem
{     
    public float AnimationLength { get; set; }
    public Action OnBegin { get; set; }
    public Action OnEnd { get; set; }
   
    private Animator _animator;

    private void Awake()
    {                
        _animator = GetComponent<Animator>();

        if (_animator == null)
        {
            Debug.Log("Error: Did not find anim!");
        }

        else
        {
            AnimationLength = _animator.runtimeAnimatorController.animationClips
                                            .First(x => x.name == "Take 001" || x.name == "mixamo.com").length;
            //AnimationLength = _anim.clip.length;            
        }
}

    public void Begin()
    {
        gameObject.SetActive(true);
        //_anim.Play();
        _animator.SetTrigger("play");
        StartCoroutine(End(AnimationLength));
    }

    public IEnumerator End(float interval)
    {
        yield return new WaitForSeconds(interval);
        OnEnd?.Invoke();
        gameObject.SetActive(false);
    }
}
