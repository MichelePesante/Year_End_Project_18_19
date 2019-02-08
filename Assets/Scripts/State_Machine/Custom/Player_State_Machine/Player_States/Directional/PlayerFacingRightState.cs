﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFacingRightState : PlayerStateBase
{
    protected override void Enter()
    {
        myContext.myPlayer.ResetFacingDirections();
        myContext.myPlayer.SetIsFacingRight(true);
        myContext.myPlayer.RotateEntity();
    }

    protected override void Tick()
    {
        myContext.myPlayer.SetIsFacingLeft(Mathf.Sign(Input.GetAxisRaw("Horizontal")) == -1);
        if (Input.GetAxisRaw("Vertical") != 0)
        {
            myContext.myPlayer.SetIsFacingUp(Mathf.Sign(Input.GetAxisRaw("Vertical")) == 1);
        }
        myContext.myPlayer.SetIsFacingDown(Mathf.Sign(Input.GetAxisRaw("Vertical")) == -1);
    }
}
