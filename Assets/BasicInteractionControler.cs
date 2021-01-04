using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BasicInteractionControler : MonoBehaviour, IInteractable
{
    [SerializeField]
    UnityEvent<GameObject> onInteraction;


    [SerializeReference]
    AControler controler;
    public AControler Controler { get => controler; set => controler = value; }

    public void Interact(AControler controler)
    {
        onInteraction.Invoke(controler.gameObject);
       
    }
}
