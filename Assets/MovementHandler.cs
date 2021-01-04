using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHandler : MonoBehaviour,IMove
{
    [SerializeField]
    ScriptableMovementOptions movementOptions;
    [SerializeField]
    Rigidbody2D rbody;

    Vector2 direction;
    int currentSpeedSetting = 0;

    public Vector2 Direction { get => direction; set => direction = value.normalized; }

    [SerializeReference]
    AControler controler;
    public AControler Controler { get => controler; set => controler=value; }

    private void FixedUpdate()
    {
        rbody.velocity = direction * movementOptions.SpeedOptions[Math.Abs(currentSpeedSetting) % movementOptions.SpeedOptions.Count];
    }
    public void UpSpeed()
    {
        currentSpeedSetting = Math.Min(currentSpeedSetting+1, movementOptions.SpeedOptions.Count);
    }
    public void DownSpeed()
    {
        currentSpeedSetting = Math.Min(currentSpeedSetting-1, movementOptions.SpeedOptions.Count);
    }
}
