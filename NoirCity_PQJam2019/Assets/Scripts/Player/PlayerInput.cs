using UnityEngine;

public class PlayerInput : MonoBehaviour
{    
    
    private PlayerController _playerController;

    private bool lockCamera = false;
    
    void Start()
    {
        _playerController = GetComponent<PlayerController>();
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

        if (!lockCamera)
        {
            var pos = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
            _playerController.Look(pos); 
        }
    }
}
