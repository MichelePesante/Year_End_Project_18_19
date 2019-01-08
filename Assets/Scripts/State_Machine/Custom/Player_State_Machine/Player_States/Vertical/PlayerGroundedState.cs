﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerStateBase
{
    protected override void Enter()
    {
        myContext.myPlayer.ResetVerticalVelocity();
        myContext.myPlayer.ResetJump();
    }

    protected override void Tick()
    {
        if (myContext.myPlayer.myRayCon.Collisions.below)
        {
            myContext.myPlayer.ResetVerticalVelocity();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            myContext.myPlayer.Jump();
        }
    }

    protected override void Exit()
    {
        myContext.myPlayer.ResetJumpsCount();
    }
}