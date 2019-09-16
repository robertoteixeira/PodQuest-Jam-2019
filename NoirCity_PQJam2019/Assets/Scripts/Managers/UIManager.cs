using System;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public GameObject MainMenuPanel;
    public GameObject SendPicturePanel;
    public GameObject GameOverPanel;

    public Action<Texture2D> OnScreenshot;

    private PlayerController _playerController;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnGameStart += OnGameStart;
        GameManager.Instance.OnGameOver += OnGameOver;

        _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        _playerController.OnSetCameraMode += OnSetCameraMode;
        _playerController.Screenshot.OnScreenshot += OnScreenShot;
    }

    private void OnGameStart()
    {
        // MainMenuPanel.SetActive(true);
        // GameOverPanel.SetActive(false);
    }

    private void OnGameOver()
    {
        MainMenuPanel.SetActive(false);
        GameOverPanel.SetActive(true);
    }

    private void OnSetCameraMode(bool status)
    {

    }

    private void OnScreenShot(Texture2D screenshot)
    {
        OnScreenshot?.Invoke(screenshot);
    }
}
