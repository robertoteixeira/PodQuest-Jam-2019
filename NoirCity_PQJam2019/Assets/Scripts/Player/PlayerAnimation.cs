using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator Anim;

    private PlayerController _playerController;
    
    void Start()
    {
        _playerController = GetComponent<PlayerController>();
        _playerController.OnSetCameraMode += OnSetCameraMode;
    }

    private void OnSetCameraMode(bool status)
    {
        Anim.SetBool("cameraOn", status);
    }
    
}
