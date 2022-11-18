using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailTrigger : CustomBehaviour
{
    public override void Initialize()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag(ObjectTags.Ball))
        {
            GameManager.Instance.LevelFailed();
        }
    }
}
