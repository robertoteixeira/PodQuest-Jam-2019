using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimeEventSubscriber : MonoBehaviour
{
    TimeManager timeManager;
    public float targetTime;
    public UnityEvent onTimeEvent;

    IDisposable disposableTimEvent;
    // Start is called before the first frame update
    void Start()
    {
        timeManager = FindObjectOfType<TimeManager>();
        disposableTimEvent = timeManager.RegisterTimeEvent(targetTime, OnTime);
        Debug.Log(disposableTimEvent);
    }

    private void OnTime()
    {
        if (onTimeEvent != null)
            onTimeEvent.Invoke();
    }
}
