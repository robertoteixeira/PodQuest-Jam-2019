﻿using UnityEngine;

public class PlayerInput : MonoBehaviour
{    
    
    private PlayerController _playerController;
    
    void Start()
    {
        _playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _playerController.Shot();
        }

        if (Input.GetButtonDown("Fire2"))
        {
            _playerController.SetCameraMode();
        }
    }
}