using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class TimeToAnimator : MonoBehaviour
{
    TimeManager timeManager;
    Animator animator;
    public string parameterName;
    public bool normalizedTime = true;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        timeManager = FindObjectOfType<TimeManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(normalizedTime)
            animator.SetFloat(parameterName, timeManager.timeOfDay / 23.99f);
        else
            animator.SetFloat(parameterName, timeManager.timeOfDay);
    }
}
