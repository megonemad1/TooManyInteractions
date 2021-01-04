using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TringgerHandler : MonoBehaviour,IHandler
{

    [SerializeReference]
    AControler controler;
    public AControler Controler { get => controler; set => controler = value; }

    [SerializeField]
    EnvlopeEvent<GameObject> onGameObjectTrigger;
    [SerializeField]
    EnvlopeEvent<Collider2D> onColliderTrigger;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        onGameObjectTrigger.onBegin.Invoke(collision.gameObject);
        onColliderTrigger.onBegin.Invoke(collision);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        onGameObjectTrigger.onEnd.Invoke(collision.gameObject);
        onColliderTrigger.onEnd.Invoke(collision);
    }
}

[System.Serializable]
public class EnvlopeEvent<T>
{
    [SerializeField]
    public UnityEvent<T> onBegin;
    [SerializeField]
    public UnityEvent<T> onEnd;
}