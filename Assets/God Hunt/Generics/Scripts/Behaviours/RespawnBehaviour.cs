﻿using UnityEngine;

public class RespawnBehaviour : BaseBehaviour
{
    [SerializeField] UnityVoidEvent OnDeathRespawn;
    [SerializeField] UnityVoidEvent OnCheckpointRespawn;

    Vector3 deathRespawnPoint;
    Vector3 checkPoint;

    public void SetRespawnPoint(Vector3 _value)
    {
        deathRespawnPoint = _value;
    }

    public void SetCheckPoint(Vector3 _value)
    {
        checkPoint = _value;
    }

    public void Respawn(bool _isDeathRespawn)
    {
        if (_isDeathRespawn)
        {
            Entity.gameObject.transform.position = deathRespawnPoint;
            OnDeathRespawn.Invoke();
        }
        else
        {
            Entity.gameObject.transform.position = checkPoint;
            OnCheckpointRespawn.Invoke();
        }
    }
}