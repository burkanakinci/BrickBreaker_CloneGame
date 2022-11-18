using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Level Data")]
public class LevelData : ScriptableObject
{

    #region Datas
    [SerializeField] private Vector3[] m_BrickPositions;
    [SerializeField] private Color[] m_BrickColor;
    #endregion

    #region ExternalAccess
    public Vector3[] BrickPositions => m_BrickPositions;
    public Color[] BrickColor => m_BrickColor;
    #endregion
}
