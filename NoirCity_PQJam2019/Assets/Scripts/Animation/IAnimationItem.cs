using System;
using System.Collections;

public interface IAnimationItem
{
    Action OnBegin { get; set; }
    Action OnEnd { get; set; }
    float AnimationLength { get; set; }

    void Begin();
    IEnumerator End(float interval);
}
