using UnityEngine;

internal interface IMove : IHandler
{

    Vector2 Direction { get; set; }
    void UpSpeed();
    void DownSpeed();
}