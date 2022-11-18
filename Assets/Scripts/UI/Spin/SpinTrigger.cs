using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinTrigger : CustomBehaviour
{
    public override void Initialize()
    {
        IsSpin = false;
    }

    public bool IsSpin;
    private SpinPiece m_SpinPieceOnSpin;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (IsSpin)
        {
            m_SpinPieceOnSpin = other.GetComponent<SpinPiece>();
            IsSpin = false;
        }
    }
}
