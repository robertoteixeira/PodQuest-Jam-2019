using System;
using UnityEngine;

public class Screenshot : IScreenshot
{
    private Camera _camera;    

    public Action<Texture2D> OnScreenshot { get; set; }
  
    public void TakeScreeenshot()
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        RenderTexture rt = new RenderTexture(Screen.width, Screen.height, 0, RenderTextureFormat.ARGB32);

        _camera.targetTexture = rt;

        CameraClearFlags clearFlags = _camera.clearFlags;
        Color background = _camera.backgroundColor;

        _camera.Render();

        RenderTexture currentRt = RenderTexture.active;
        RenderTexture.active = _camera.targetTexture;

        Texture2D screenshot = new Texture2D(Screen.width, Screen.height, TextureFormat.ARGB32, false);
        screenshot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0, false);

        if (QualitySettings.activeColorSpace == ColorSpace.Linear)
        {
            Color[] pixels = screenshot.GetPixels();
            for (int i = 0; i < pixels.Length; i++)
            {
                pixels[i] = pixels[i].gamma;
            }
            screenshot.SetPixels(pixels);
        }

        screenshot.Apply(false);

        _camera.targetTexture = null;
        RenderTexture.active = currentRt;

        OnScreenshot?.Invoke(screenshot);
    }
    
}
