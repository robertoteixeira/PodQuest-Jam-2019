using System;
using System.Collections;
using UnityEngine;

public class AnimationItem : MonoBehaviour
{
    public bool IsMain;
    public float AnimationLength;

    public Action OnBegin;
    public Action OnEnd;

    private Animator _animator;
    private Animation _anim;

    private void Awake()
    {
        //_animator = GetComponent<Animator>();
        _anim = GetComponent<Animation>();

        if (_anim == null)
        {
            Debug.Log("Error: Did not find anim!");
        }

        else
        {
            //AnimationClip[] clips = _animator.runtimeAnimatorController.animationClips;
            //foreach (AnimationClip clip in clips)
            //{
            //    if (clip.name == "Main")
            //    {
            //        AnimationLength = clip.length;                    
            //    }
            //}

            AnimationLength = _anim.clip.length;            
        }
    }

    public void Begin()
    {
        //_animator.SetTrigger("begin");
        _anim.Play();
        StartCoroutine(End(AnimationLength));
    }

    private IEnumerator End(float interval)
    {
        yield return new WaitForSeconds(interval);
        OnEnd?.Invoke();
    }
    
}
