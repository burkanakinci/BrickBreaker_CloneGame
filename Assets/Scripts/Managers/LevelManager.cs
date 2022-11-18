
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : CustomBehaviour
{
    #region Fields
    private LevelData m_LevelData;
    private int m_CurrentLevelNumber;
    private int m_ActiveLevelDataNumber;
    private int m_MaxLevelDataCount;
    #endregion

    #region ExternalAccess

    #endregion

    #region Actions
    public event Action OnCleanSceneObject;
    #endregion

    public override void Initialize()
    {

        GameManager.Instance.OnResetToMainMenu += OnResetToMainMenu;
        GameManager.Instance.OnGameStart += OnGameStart;
        GameManager.Instance.OnLevelCompleted += OnLevelCompleted;
        GameManager.Instance.OnLevelFailed += OnLevelFailed;

        m_MaxLevelDataCount = Resources.LoadAll("LevelDatas", typeof(LevelData)).Length;
    }

    private void GetLevelData()
    {
        m_ActiveLevelDataNumber = (m_CurrentLevelNumber <= m_MaxLevelDataCount) ? (m_CurrentLevelNumber) : ((int)(UnityEngine.Random.Range(1, (m_MaxLevelDataCount + 1))));
        m_LevelData = Resources.Load<LevelData>("LevelDatas/" + m_ActiveLevelDataNumber + "MainLevelData");
    }
    #region SpawnSceneObject
    private void SpawnSceneObjects()
    {
    }
    #endregion

    #region Events
    private void OnResetToMainMenu()
    {
        OnCleanSceneObject?.Invoke();
    }

    private void OnGameStart()
    {
        m_CurrentLevelNumber = GameManager.Instance.PlayerManager.GetLevelNumber();

        GetLevelData();
        SpawnSceneObjects();
    }
    private void OnLevelCompleted()
    {
    }
    private void OnLevelFailed()
    {
    }
    private void OnDestroy()
    {
        GameManager.Instance.OnResetToMainMenu -= OnResetToMainMenu;
        GameManager.Instance.OnGameStart -= OnGameStart;
        GameManager.Instance.OnLevelCompleted -= OnLevelCompleted;
        GameManager.Instance.OnLevelFailed -= OnLevelFailed;
    }
    #endregion
}
