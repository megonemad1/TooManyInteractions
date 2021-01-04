using UnityEngine;

public interface IInteractable: IHandler
{
    void Interact(AControler gameObject);
}