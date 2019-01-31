﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterRaycastRoom : RaycastController
{
    [HideInInspector]
    /// <summary>
    /// Se true, il player ha superato il trigger della stanza
    /// </summary>
    public bool IsPlayerPassedThrough;

    [SerializeField]
    /// <summary>
    /// Se true, il trigger si attiva dall'alto e dal basso, altrimenti da destra e sinistra
    /// </summary>
    [Tooltip("Se true, il trigger si attiva dall'alto e dal basso, altrimenti da destra e sinistra")]
    private bool isHorizontal;

    [SerializeField]
    /// <summary>
    /// Stanze che bisogna attivare al sorpasso di questo trigger
    /// </summary>
    [Tooltip("Stanze che bisogna attivare al sorpasso di questo trigger")]
    private List<RoomController> roomsToEnable;

    /// <summary>
    /// Funzione che lancia dei raycasts, serve a capire quando il player esce o entra da una stanza
    /// </summary>
    public void CheckEnterTrigger()
    {
        if (isHorizontal)
        {
            for (int i = 0; i < 2; i++)
            {
                Vector2 rayOrigin = myRaycastOrigins.BottomLeft;
                rayOrigin += Vector2.up * (myCollider.bounds.size.y * i);
                RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right, myCollider.bounds.size.x, GeneralMask);

                Debug.DrawRay(rayOrigin, Vector2.right * myCollider.size.x, Color.red);

                if (hit) // Mentre colpisco qualcosa
                {
                    foreach (RoomController room in roomsToEnable)
                    {
                        room.EnableRoom();
                    }

                    IsPlayerPassedThrough = true;
                }
            }
        }
        else
        {
            for (int i = 0; i < 2; i++)
            {
                Vector2 rayOrigin = myRaycastOrigins.BottomLeft;
                rayOrigin += Vector2.right * (myCollider.bounds.size.x * i);
                RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up, myCollider.bounds.size.y, GeneralMask);

                Debug.DrawRay(rayOrigin, Vector2.up * myCollider.size.y, Color.red);

                if (hit) // Mentre colpisco qualcosa
                {
                    foreach (RoomController room in roomsToEnable)
                    {
                        room.EnableRoom();
                    }

                    IsPlayerPassedThrough = true;
                }
            }
        }
    }
}