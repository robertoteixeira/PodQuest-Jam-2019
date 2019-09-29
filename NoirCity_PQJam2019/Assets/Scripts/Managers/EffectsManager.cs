using System;
using System.Collections;
using UnityEngine;

public class EffectsManager : Singleton<EffectsManager>
{
    public GameObject CameraEffect;

    private PlayerController _playerController;

    // Start is called before the first frame update
    void Start()
    {
        _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        _playerController.OnSetCameraMode += OnCameraSetMode;
    }

    private void OnCameraSetMode(bool status)
    {
        StartCoroutine(SetCammera(status));        
    }    

    private IEnumerator SetCammera(bool status)
    {
        if (status)
        {
            yield return new WaitForSeconds(TimeSpan.FromMilliseconds(1000).Seconds);
            CameraEffect.SetActive(true);
        }
        else
        {
            CameraEffect.SetActive(false);
        }
    }
}
