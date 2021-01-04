using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    [SerializeReference]
    AControler controler;
    [SerializeField]
    KeyCode Sprint;
    IMove mover;

    private void Awake()
    {
        mover = controler.GetHandler<IMove>();
    }

    void Update()
    {
        mover.Direction = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
        if (Input.GetKeyDown(Sprint))
        {
            mover.UpSpeed();
        }
        if (Input.GetKeyUp(Sprint))
        {
            mover.DownSpeed();
        }
    }
}
