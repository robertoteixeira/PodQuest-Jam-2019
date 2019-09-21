using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class TimeManager : MonoBehaviour
{

    public float dayLengthInMinutes;
    public float  timeOfDay;
    ReactiveProperty<float> reactiveTimeOfDay;
    public float startTime;
    IObservable<float> timeObservable;
    IDisposable timeDisposable;
    public Action<float> OnTime;

    IDisposable almoco;

    private void Awake()
    {
        reactiveTimeOfDay = new ReactiveProperty<float>(startTime);
        Init(startTime);
        almoco = RegisterTimeEvent(12f,null);
    }
    // Start is called before the first frame update
    void Init(float initialValue)
    {
        if (timeDisposable != null)
            timeDisposable.Dispose();

        timeOfDay = initialValue;
        timeObservable = CustomObservable.Tween(initialValue, 23.99f, dayLengthInMinutes * 360);
        timeDisposable = timeObservable.Subscribe(progress => timeOfDay = reactiveTimeOfDay.Value = progress);
    }

    // Update is called once per frame
    void Update()
    {
        if (timeOfDay >= 23.99f)
        {
            timeOfDay = 0;
            Init(0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
            UnRegisterTimeEvent(almoco);
    }

    public List<IDisposable> timeEventDisposables = new List<IDisposable>();
    public IDisposable RegisterTimeEvent(float targetTime, Action callback)
    {
        var timeEventObservable = reactiveTimeOfDay.Where(timeOfDay => Mathf.Abs(timeOfDay - targetTime) <= 0.01f);
        var timeEventDisposable = timeEventObservable.Subscribe(_ =>
        {
            Observable.Timer(TimeSpan.FromSeconds(1)).AsUnitObservable();
            callback.Invoke();
        });
        timeEventDisposables.Add(timeEventDisposable);
        return timeEventDisposable;
    }

    public void UnRegisterTimeEvent(IDisposable disposable)
    {
        timeEventDisposables.Find(a => a == disposable).Dispose();
        timeEventDisposables.Remove(disposable);
    }
}
