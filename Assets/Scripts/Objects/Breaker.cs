using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breaker : CustomBehaviour
{
    #region Fields
    [SerializeField] private GameObject m_BreakerVisual;
    [SerializeField] private Ball m_Ball;
    [SerializeField] private Transform m_BallStartPosition;
    [SerializeField] private float m_HorizontalMovementMultiplier;
    #endregion
    public override void Initialize()
    {

        m_Ball.Initialize();

        GameManager.Instance.OnResetToMainMenu += OnResetToMainMenu;
        GameManager.Instance.OnGameStart += OnGameStart;
        GameManager.Instance.OnLevelCompleted += OnLevelCompleted;
        GameManager.Instance.OnLevelFailed += OnLevelFailed;
        GameManager.Instance.InputManager.OnSwiped += OnSwiped;
    }

    private float m_SwipeValue;
    private Vector3 m_TargetPosition;
    private void OnSwiped(float _swipeValue)
    {
        m_SwipeValue = _swipeValue;
        m_TargetPosition = transform.position;
        m_TargetPosition.x += (_swipeValue * m_HorizontalMovementMultiplier);
        m_TargetPosition.x = Mathf.Clamp(m_TargetPosition.x, -1.75f, 1.75f);
        transform.position = m_TargetPosition;
    }
    private void ResetBreaker()
    {
        m_Ball.gameObject.SetActive(false);
        m_Ball.transform.position = m_BallStartPosition.position;
        transform.position = Vector3.up * -4.5f;
        m_BreakerVisual.SetActive(false);
    }

    public Color GetBallColor()
    {
        return m_Ball.BallSpriteRenderer.color;
    }
    public void SetBallColor(Color _color)
    {
        m_Ball.BallSpriteRenderer.color = _color;
    }

    #region Events
    private void OnResetToMainMenu()
    {
        ResetBreaker();
    }

    private void OnGameStart()
    {
        m_Ball.gameObject.SetActive(true);
        m_BreakerVisual.SetActive(true);
    }
    private void OnLevelCompleted()
    {
    }
    private void OnLevelFailed()
    {
        ResetBreaker();
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
