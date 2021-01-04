using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField]
    bool _enabled;
    [SerializeField]
    float intervel = 1;
    [SerializeField]
    UnityEvent onTick;

    public bool TimerEnabled { get => _enabled; set => _enabled = value; }

    private void Awake()
    {
        StartCoroutine(Tick());
    }
    IEnumerator Tick()
    {
        while(true)
        {
            while (_enabled)
            {
                yield return new WaitForSeconds(intervel);
                if (_enabled)
                    onTick.Invoke();
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
