using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinReward
{
    private List<IReward> m_Rewards;

    public SpinReward()
    {
        m_Rewards = new List<IReward>();
        m_Rewards.Add(new EarnCoinReward());
    }

    public IReward GetRewardByType(SpinRewardType _rewardType)
    {
        return m_Rewards[(int)_rewardType];
    }
}
