using System;
using System.Collections;
using UniRx;
using UnityEngine;
using System.Threading;

namespace UniRx
{

    public static partial class CustomObservable
    {

        /// <summary>
        /// Tween in seconds
        /// </summary>
        public static IObservable<Vector2> Tween(Vector2 from, Vector2 to, float seconds)
        {
            Vector2 delta = to - from;
            Func<float, Vector2> lerpFunc = (progress) => { return from + (delta * progress); };
            return UniRx.Observable.FromMicroCoroutine<Vector2>((observer, cancellationToken) => TweenEveryCycleCore(observer, from, to, seconds, lerpFunc, cancellationToken), FrameCountType.Update);
        }

        public static IObservable<Vector3> Tween(Vector3 from, Vector3 to, float seconds)
        {
            Vector3 delta = to - from;
            Func<float, Vector3> lerpFunc = (progress) => { return from + (delta * progress); };
            return UniRx.Observable.FromMicroCoroutine<Vector3>((observer, cancellationToken) => TweenEveryCycleCore(observer, from, to, seconds, lerpFunc, cancellationToken), FrameCountType.Update);
        }

        public static IObservable<float> Tween(float from, float to, float seconds)
        {
            float delta = to - from;
            Func<float, float> lerpFunc = (progress) => { return from + (delta * progress); };
            return UniRx.Observable.FromMicroCoroutine<float>((observer, cancellationToken) => TweenEveryCycleCore(observer, from, to, seconds, lerpFunc, cancellationToken), FrameCountType.Update);
        }

        public static IObservable<Quaternion> Tween(Quaternion from, Quaternion to, float seconds)
        {
            Func<float, Quaternion> lerpFunc = (progress) => { return Quaternion.Lerp(from, to, progress); };
            return UniRx.Observable.FromMicroCoroutine<Quaternion>((observer, cancellationToken) => TweenEveryCycleCore(observer, from, to, seconds, lerpFunc, cancellationToken), FrameCountType.Update);
        }

        static IEnumerator TweenEveryCycleCore<T>(IObserver<T> observer, T from, T to, float seconds, Func<float, T> lerpFunc, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) yield break;
            if (seconds <= 0)
            {
                observer.OnNext(to);
                observer.OnCompleted();
                yield break;
            }
            float totalTime = 0f;
            observer.OnNext(from);
            while (true)
            {
                yield return null;
                if (cancellationToken.IsCancellationRequested) yield break;

                totalTime += UnityEngine.Time.deltaTime;
                if (totalTime >= seconds)
                {
                    observer.OnNext(to);
                    observer.OnCompleted();
                    yield break;
                }
                else
                {
                    float normalizedTime = totalTime / seconds;
                    observer.OnNext(lerpFunc(normalizedTime));
                }
            }
        }
    }

}