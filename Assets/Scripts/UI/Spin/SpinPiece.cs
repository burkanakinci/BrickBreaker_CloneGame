using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinPiece : CustomBehaviour
{
    #region Fields
    [SerializeField] private int m_RewardValue;
    [SerializeField] private SpinRewardType m_SpinRewardType;
    #endregion

    #region ExternalAccess
    public int RewardValue => m_RewardValue;
    public SpinRewardType SpinRewardType => m_SpinRewardType;
    #endregion
    public override void Initialize()
    {
    }

}
