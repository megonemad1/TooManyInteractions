using System.Collections.Generic;
using UnityEngine;

public abstract class AControler:MonoBehaviour
{
    public abstract void  addHandler(IHandler h);
    public abstract void  removeHandler(IHandler h);
    public abstract T GetHandler<T>() where T: IHandler;
    public abstract IEnumerable<T> GetHandlers<T>() where T : IHandler;
}