using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

public class EntityControler : AControler
{
    [SerializeField]
    List<Component> _handlers = new List<Component>();
    List<IHandler> handlers = new List<IHandler>();
    private void OnValidate()
    {
        _handlers = _handlers.Where(c => c as IHandler != null).Distinct().ToList();
        IEnumerable<IHandler> localList = _handlers.Select(c => c as IHandler);
        IEnumerable<IHandler> added = localList.Where(c => !handlers.Contains(c));
        IEnumerable<IHandler> removed = handlers.Where(c => !localList.Contains(c));
        foreach (IHandler h in added)
            addHandler(h);
        foreach (IHandler h in removed)
            removeHandler(h);
    }
    public void addHandler(Component h)
    {

        var handler = h as IHandler;
        if (handler != null)
            addHandler(handler);
        else
            Debug.LogError($"failed to find handler in {h.name}", gameObject);
    }
    
    public override void addHandler(IHandler h)
    {
        if (!handlers.Contains(h))
        {
            handlers.Add(h);
            h.Controler = this;
        }
    }
    public override void removeHandler(IHandler h)
    {
        if (handlers.Remove(h))
            h.Controler = null;
    }
    public override T GetHandler<T>()
    {
        return (T) handlers.FirstOrDefault(h => typeof(T).IsAssignableFrom(h.GetType()));
    }
    public override IEnumerable<T> GetHandlers<T>() 
    {
        return handlers.Where(h =>  typeof(T).IsAssignableFrom(h.GetType())).Select(h=>(T)h);
    }
}
