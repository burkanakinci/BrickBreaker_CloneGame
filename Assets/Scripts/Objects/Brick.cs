using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : CustomBehaviour, IPooledObject
{
    [SerializeField] private SpriteRenderer m_BrickSpriteRenderer;
    public override void Initialize()
    {
    }
    public void OnObjectSpawn()
    {
        GameManager.Instance.OnLevelFailed += OnObjectDeactive;
    }
    public void OnObjectDeactive()
    {
        GameManager.Instance.OnLevelFailed -= OnObjectDeactive;
        GameManager.Instance.ObjectPool.AddObjectPool(PooledObjectTags.Brick, this);
        this.gameObject.SetActive(false);
    }
    public CustomBehaviour GetGameObject()
    {
        return this;
    }
    private void BreakBrick()
    {
        GameManager.Instance.LevelManager.BrickedCount++;
        GameManager.Instance.ObjectPool.SpawnFromPool(PooledObjectTags.ConfettiParticle,transform.position,Quaternion.identity,null);

        if(GameManager.Instance.LevelManager.BrickedCount==GameManager.Instance.LevelManager.BrickCount)
        {
            GameManager.Instance.LevelCompleted();
        }
        OnObjectDeactive();
    }

    public void SetBrickColor(Color _color)
    {
        m_BrickSpriteRenderer.color = _color;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(ObjectTags.Ball))
        {
            if (GameManager.Instance.Breaker.GetBallColor() == m_BrickSpriteRenderer.color)
            {
                BreakBrick();
            }
            else
            {
                GameManager.Instance.Breaker.SetBallColor(m_BrickSpriteRenderer.color);
            }
        }
    }
}
