using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour, IHandler
{
    [SerializeReference]
    AControler controler;

    public AControler Controler { get => controler; set => controler=value; }

    public void InteractWith(GameObject g)
    {
        var interactionHandler = g.GetComponent<IInteractable>();
        if (interactionHandler != null)
        {
            interactionHandler.Interact(Controler);
        }
    }
}
