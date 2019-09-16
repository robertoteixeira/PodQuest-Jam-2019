using System;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Action OnGameStart;
    public Action OnLevelStart;
    public Action OnGamePause;
    public Action OnGameOver;    
    
    // Start is called before the first frame update
    void Start()
    {
        OnGameStart?.Invoke();
        OnLevelStart?.Invoke();
    }
    
}
