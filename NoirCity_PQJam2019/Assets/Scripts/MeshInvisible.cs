using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshInvisible : MonoBehaviour
{
    public GameObject MeshToHide;

    private PlayerController _playerController;

    void Start()
    {
        _playerController = GetComponent<PlayerController>();
        _playerController.OnSetCameraMode += (status) =>
        {
            StartCoroutine(Hide(status));
        };
    }

    private IEnumerator Hide(bool status)
    {
        if (status)
        {
            yield return new WaitForSeconds(TimeSpan.FromMilliseconds(2000).Seconds);
            MeshToHide.SetActive(false);
        }
        else
        {            
            MeshToHide.SetActive(true);
        }            
    }
}
