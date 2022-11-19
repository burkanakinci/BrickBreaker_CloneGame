using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class InputManager : CustomBehaviour
{
    #region Fields
    [SerializeField] private float m_MinimumSwipeDistanceInViewportPoint;
    private float m_ChangeOfMousePos, m_HorizontalMovementChange;
    private Vector2 m_FirstMousePos;
    private bool m_IsUIOverride;
    private float m_ScreenWidth;
    #endregion

    #region Actions
    public event Action<float> OnSwiped;
    #endregion

    public override void Initialize()
    {
        m_ScreenWidth = Screen.width;
        m_HorizontalMovementChange = 0.0f;

        GameManager.Instance.OnResetToMainMenu += OnResetToMainMenu;
        GameManager.Instance.OnGameStart += OnStartGame;
    }
    private void Update()
    {
        UpdateUIOverride();
        UpdateInput();
#if UNITY_EDITOR
        UpdateKeybordInput();
#endif
    }
#if UNITY_EDITOR
    private void UpdateKeybordInput()
    {
        if ((Input.GetKey(KeyCode.A)) ||
        (Input.GetKey(KeyCode.D)))
        {
            m_HorizontalMovementChange = Input.GetAxis("Horizontal") / m_ScreenWidth * 10.0f;

            OnSwiped?.Invoke(m_HorizontalMovementChange);
        }
    }
#endif
    public void UpdateInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!m_IsUIOverride)
            {
                TouchControlsDown();
            }
        }
        else if (Input.GetMouseButton(0))
        {
            if (!m_IsUIOverride)
            {
                TouchControls();

                OnSwiped?.Invoke(m_HorizontalMovementChange);
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (!m_IsUIOverride)
            {
                TouchControlsUp();

                OnSwiped?.Invoke(m_HorizontalMovementChange);
            }
        }

    }

    public void UpdateUIOverride()
    {
        m_IsUIOverride = EventSystem.current.IsPointerOverGameObject(0);
    }
    public void TouchControlsDown()
    {
        m_FirstMousePos = Input.mousePosition;
    }
    public void TouchControls()
    {

        m_HorizontalMovementChange = 0;

        m_ChangeOfMousePos = Input.mousePosition.x - m_FirstMousePos.x;
        if (Mathf.Abs(m_ChangeOfMousePos) > m_MinimumSwipeDistanceInViewportPoint)
        {

            m_HorizontalMovementChange = (m_ChangeOfMousePos / m_ScreenWidth);
            m_FirstMousePos = Input.mousePosition;
        }

    }
    public void TouchControlsUp()
    {
        m_HorizontalMovementChange = 0;
        m_FirstMousePos = Input.mousePosition;
    }

    #region Events
    private void OnStartGame()
    {
    }

    private void OnResetToMainMenu()
    {
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnResetToMainMenu -= OnResetToMainMenu;
        GameManager.Instance.OnGameStart -= OnStartGame;
    }

    #endregion
}
