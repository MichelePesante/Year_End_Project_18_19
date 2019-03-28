﻿using UnityEngine;

namespace Refactoring
{
    public class PlatformEntity : BoxColliderEntity
    {

        public override void CustomSetup()
        {
            Data = new PlatformEntityData(GetComponentInChildren<BoxCollider>());
        }
    } 

    public class PlatformEntityData : BoxColliderEntityData
    {
        public PlatformEntityData(BoxCollider _bc)
        {
            collider = _bc;
        }
    }
}