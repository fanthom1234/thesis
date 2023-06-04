using System.Collections;
using UnityEngine;
using Thesis;

public class GrowMethod : Method
{
    public Transform targetScale;

    public override IEnumerator Action(BaseClass baseClass)
    {
        // targetScale = baseClassGO.transform;
        float varValue = int.Parse(variable.GetVariableValue());
        targetScale.localScale = new Vector3(varValue, varValue, varValue);

        if (!variable.IsReachMax())
            variable.IncreaseVariableValue();
        Debug.Log("finish grow");
        yield return null;
    }
}
