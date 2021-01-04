using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
internal class ScriptableMovementOptions:ScriptableObject
{
    [SerializeField]
    public List<float> SpeedOptions= new List<float>();
}