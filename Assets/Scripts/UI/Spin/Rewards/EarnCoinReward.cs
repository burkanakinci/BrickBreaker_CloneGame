using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarnCoinReward : IReward
{
    public EarnCoinReward()
    {

    }

    public void GetReward(int _rewardValue)
    {
        int m_UpdatedCoinValue = GameManager.Instance.PlayerManager.GetTotalCoinCount() + _rewardValue;
        GameManager.Instance.PlayerManager.UpdateTotalCoinCountData(m_UpdatedCoinValue);
    }
}
