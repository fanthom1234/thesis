using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Thesis;

public class OpenMethod : Method
{
    public override IEnumerator Action(BaseClass baseClass)
    {
        //baseClass.gameObject.transform.GetChild(0).gameObject.SetActive(false);

        if (variable.GetType().Name != "VariableBool")
            yield return null;

        baseClass.gameObject.SetActive(false);

        yield return null;
    }
}
