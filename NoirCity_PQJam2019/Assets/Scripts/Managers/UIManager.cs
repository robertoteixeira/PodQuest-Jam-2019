using System;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public GameObject MainMenuPanel;
    public GameObject SendPicturePanel;
    public GameObject GameOverPanel;
    public GameObject MissionPanel;
    public GameObject PhotoPanel;
    public GameObject MissionFinishPanel;

    public Action<Texture2D> OnScreenshot;

    private PlayerController _playerController;

    private void Awake()
    {
        this.Reload();
    }

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
        ShowPhotoPanel();
    }

    public void ShowMissionPanel()
    {
        MissionPanel.SetActive(true);
    }

    public void HideMissionPanel()
    {
        MissionPanel.SetActive(false);
    }

    public void ShowPhotoPanel()
    {
        PhotoPanel.SetActive(true);
    }

    public void HidePhotoPanel()
    {
        PhotoPanel.SetActive(false);
    }

    public void ShowMissionFinishPanel()
    {        
        GameObject.Find("MissionFinisher").GetComponent<MissionFinisher>().FinishMission();
        MissionFinishPanel.SetActive(true);
    }

    public void HideMissionFinishPanel()
    {
        MissionFinishPanel.SetActive(false);
    }
  
}
