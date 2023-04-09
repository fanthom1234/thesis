using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Thesis;

public abstract class Method : MonoBehaviour
{
    public abstract Transform targetTF { get; }
    public abstract float actingDuration { get; }
    public abstract VariableType variableNeeded { get; }
    public abstract void Action(GameObject from);
}
