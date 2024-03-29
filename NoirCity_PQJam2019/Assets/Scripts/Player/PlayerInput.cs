﻿using UnityEngine;

public class PlayerInput : MonoBehaviour
{    
    
    private PlayerController _playerController;

    private bool lockCamera = true;
    
    void Start()
    {
        _playerController = GetComponent<PlayerController>();
        CursorManager.Instance.OnHideCursor += () => lockCamera = false;
        CursorManager.Instance.OnShowCursor += () => lockCamera = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _playerController.Shot();
        }

        if (Input.GetMouseButtonDown(1))
        {
            _playerController.SetCameraMode();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            lockCamera = !lockCamera;
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            lockCamera = !lockCamera;
        }

        if (Input.GetKey(KeyCode.Tab))
        {
            UIManager.Instance.ShowMissionPanel();
            CursorManager.Instance.ShowCursor();
        }

        if (Input.GetKeyUp(KeyCode.Tab))
        {
            UIManager.Instance.HideMissionPanel();
            CursorManager.Instance.HideCursor();
        }

        if (!lockCamera)
        {
            var pos = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
            _playerController.Look(pos); 
        }
    }
}
