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

    private StatusManager _statusManager;
    
    void Awake()
    {
        Screenshot = new Screenshot();
        GameManager.Instance.OnLevelStart += OnLevelStart;
        _statusManager = GameObject.Find("StatusManager").GetComponent<StatusManager>();
    }

    private void OnLevelStart()
    {
        ShotsAvailable = MaxShots;
    }

    public void Shot()
    {
        if (IsCameraModeOn)
        {
            //if (ShotsAvailable > 0)
            if (true)
            {
                GetObjectsOnCamera();
                ShotsAvailable--;
                Debug.Log("Shot!");
                OnShot?.Invoke(ShotsAvailable);
                Screenshot.TakeScreeenshot();                
                SetCameraMode();
                CursorManager.Instance.ShowCursor();
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

    public void GetObjectsOnCamera()
    {
        var elementsOnCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerVision>()
            .GetVisibleList("AnimItem");

        foreach (var item in elementsOnCamera)
        {
            if (item.name == "Caso1" || item.name == "Caso2" || item.name == "Caso3")
            {
                _statusManager.CaughtOnCamera = true;
            }
        }
    }

}
