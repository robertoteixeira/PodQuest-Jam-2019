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
        CameraEffect.SetActive(status);
    }    
}
