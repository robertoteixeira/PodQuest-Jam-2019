using System;

public class GameManager : Singleton<GameManager>
{
    public Action OnGameStart;
    public Action OnLevelStart;
    public Action OnGamePause;
    public Action OnGameOver;

    private void Awake()
    {
        this.Reload();
    }

    // Start is called before the first frame update
    void Start()
    {
        OnGameStart?.Invoke();        
    }

    public void LevelStart()
    {
        OnLevelStart?.Invoke();
    }

    public void SendPhoto()
    {
        UIManager.Instance.ShowMissionFinishPanel();
    }
    
}
