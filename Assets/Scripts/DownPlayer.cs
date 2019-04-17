using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownPlayer : PlayerController
{
    public override void Jumping()
    {
        m_playerRigid.AddForce(new Vector2(0, -m_ForceJump));
    }
}
