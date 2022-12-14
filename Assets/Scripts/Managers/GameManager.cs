using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : CustomBehaviour
{
    public static GameManager Instance { get; private set; }
    #region Fields
    public ObjectPool ObjectPool;
    public PlayerManager PlayerManager;
    public JsonConverter JsonConverter;
    public LevelManager LevelManager;
    public UIManager UIManager;
    public InputManager InputManager;
    public Breaker Breaker;
    public Spin Spin;
    #endregion

    #region Actions
    public event Action OnResetToMainMenu;
    public event Action OnLevelCompleted;
    public event Action OnLevelFailed;
    public event Action OnGameStart;
    #endregion
    private void Awake()
    {
        Instance = this;

        Application.targetFrameRate = 60;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Initialize();
    }
    public override void Initialize()
    {
        ObjectPool.Initialize();
        JsonConverter.Initialize();
        PlayerManager.Initialize();
        InputManager.Initialize();
        
        UIManager.Initialize();
        LevelManager.Initialize();
        Breaker.Initialize();
        Spin.Initialize();
    }
    private void Start()
    {
        ResetToMainMenu();
    }
    public void ResetToMainMenu()
    {
        OnResetToMainMenu?.Invoke();
    }
    public void LevelFailed()
    {
        OnLevelFailed?.Invoke();
    }
    public void LevelCompleted()
    {
        OnLevelCompleted?.Invoke();
    }
    public void GameStart()
    {
        OnGameStart?.Invoke();
    }
}
