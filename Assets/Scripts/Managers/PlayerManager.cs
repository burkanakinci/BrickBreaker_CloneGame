using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerManager : CustomBehaviour
{
    #region Fields
    #endregion
    #region ExternalAccess

    #endregion
    public override void Initialize()
    {

        GameManager.Instance.OnResetToMainMenu += OnResetToMainMenu;
        GameManager.Instance.OnLevelCompleted += OnLevelCompleted;
        GameManager.Instance.OnLevelFailed += OnLevelFailed;

    }
    public void UpdateTotalCoinCountData(int _coinCount)
    {
        GameManager.Instance.JsonConverter.PlayerData.TotalCoinCount = _coinCount;
        GameManager.Instance.JsonConverter.SavePlayerData();
        Debug.Log(GetTotalCoinCount());
    }
    public int GetTotalCoinCount()
    {
        return GameManager.Instance.JsonConverter.PlayerData.TotalCoinCount;
    }
    public void UpdateStickmanCountData(int _coinCount)
    {
        GameManager.Instance.JsonConverter.PlayerData.StickmanCount = _coinCount;
        GameManager.Instance.JsonConverter.SavePlayerData();
    }
    public int GetStickmanCount()
    {
        return GameManager.Instance.JsonConverter.PlayerData.StickmanCount;
    }
    public void UpdateLevelData(int _levelNumber)
    {
        GameManager.Instance.JsonConverter.PlayerData.LevelNumber = _levelNumber;
        GameManager.Instance.JsonConverter.SavePlayerData();
    }
    public int GetLevelNumber()
    {
        return GameManager.Instance.JsonConverter.PlayerData.LevelNumber;
    }

    #region Events

    private void OnResetToMainMenu()
    {
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
        GameManager.Instance.OnLevelCompleted -= OnLevelCompleted;
        GameManager.Instance.OnLevelFailed -= OnLevelFailed;
    }

    #endregion
}
