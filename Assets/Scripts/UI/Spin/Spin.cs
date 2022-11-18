using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Spin : CustomBehaviour
{
    #region Fields
    [SerializeField] private SpinTrigger m_SpinTrigger;
    [SerializeField] private RectTransform m_SpinRectTransform;
    [SerializeField] private List<SpinPiece> m_SpinPieces;
    private SpinReward m_SpinReward;
    #endregion

    public override void Initialize()
    {
        m_SpinRotateTweenID = GetInstanceID() + "m_SpinRotateTweenID";

        m_SpinTrigger.Initialize();
        m_SpinPieces.ForEach(x =>
            x.Initialize()
        );
        m_SpinReward = new SpinReward();
    }

    private string m_SpinRotateTweenID;
    private float m_RotateLerpValue;
    private float m_RandomZRotate, m_RemainingZRotate;
    private Vector3 m_StartAngle, m_FinishAngle;
    public void RotateSpin()
    {
        DOTween.Kill(m_SpinRotateTweenID);

        m_RandomZRotate = Random.Range((360.0f * 4), (360.0f * 6));

        m_StartAngle = m_SpinRectTransform.localEulerAngles;
        m_FinishAngle = (m_SpinRectTransform.localEulerAngles - (Vector3.forward * m_RandomZRotate));
        m_RemainingZRotate = (m_FinishAngle.z % 51.42f);
        m_FinishAngle.z -= m_RemainingZRotate;

        m_RotateLerpValue = 0.0f;
        DOTween.To(() => m_RotateLerpValue, x => m_RotateLerpValue = x, 1.0f, 1.0f).
        OnStart(() =>
        {
            m_SpinTrigger.IsSpin = false;
        }).
        OnUpdate(() =>
        {
            m_SpinRectTransform.localEulerAngles = Vector3.Lerp(m_StartAngle, m_FinishAngle, m_RotateLerpValue);
        }).
        OnComplete(() =>
        {
            m_SpinTrigger.IsSpin = true;
        }).
        SetId(m_SpinRotateTweenID).
        SetEase(Ease.OutExpo);
    }

    public void GetRewardOnSpin(SpinRewardType _rewardType, int _rewardValue)
    {
        m_SpinReward.GetRewardByType(_rewardType).GetReward(_rewardValue);
    }
}
