using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool IsCameraModeOn = false;
    public int MaxShots = 3;
    public int ShotsAvailable;
    public CameraLook CameraLook;

    public Action<int> OnShot;
    public Action<bool> OnSetCameraMode;

    public IScreenshot Screenshot;
    
    void Awake()
    {
        Screenshot = new Screenshot();
        GameManager.Instance.OnLevelStart += OnLevelStart;
    }

    private void OnLevelStart()
    {
        ShotsAvailable = MaxShots;
    }

    public void Shot()
    {
        if (IsCameraModeOn)
        {
            if (ShotsAvailable > 0)
            {                
                ShotsAvailable--;
                Debug.Log("Shot!");
                OnShot?.Invoke(ShotsAvailable);
                Screenshot.TakeScreeenshot();
                AudioManager.Instance.PlaySoundEffect();
            }
            else
            {
                Debug.Log("0 shots available!");
            }
        }            
    }

    public void SetCameraMode()
    {
        IsCameraModeOn = !IsCameraModeOn;
        OnSetCameraMode?.Invoke(IsCameraModeOn);
        Debug.Log("Camera Mode On: " + IsCameraModeOn);
    }

    public void Look(Vector2 position)
    {
        CameraLook.Look(position);
    }

}
