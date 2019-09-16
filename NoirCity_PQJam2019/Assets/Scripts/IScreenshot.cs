using System;
using UnityEngine;

public interface IScreenshot
{
    Action<Texture2D> OnScreenshot { get; set; }

    void TakeScreeenshot();
}
