using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : CustomBehaviour
{
    #region Fields
    [SerializeField] private Rigidbody2D m_BallRB;
    [SerializeField] private float m_BallVelocityMultiplier;
    #endregion
    public override void Initialize()
    {

        GameManager.Instance.OnResetToMainMenu += OnResetToMainMenu;
        GameManager.Instance.OnGameStart += OnGameStart;
        GameManager.Instance.OnLevelCompleted += OnLevelCompleted;
        GameManager.Instance.OnLevelFailed += OnLevelFailed;
    }

    private Vector3 m_TargetVelocity;
    private void FixedUpdate()
    {
        m_BallRB.velocity = m_TargetVelocity * m_BallVelocityMultiplier;
    }

    private Vector3 m_LookPos, m_LookAngle;
    private Quaternion m_LookRotation;
    private void OnCollisionEnter2D(Collision2D other)
    {
        m_TargetVelocity = (Vector3.Reflect(transform.position, other.contacts[0].normal));
    }

    #region Events
    private void OnResetToMainMenu()
    {
    }

    private void OnGameStart()
    {
        m_TargetVelocity = Vector3.up * m_BallVelocityMultiplier;
        transform.eulerAngles = Vector3.right * -90.0f;
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
