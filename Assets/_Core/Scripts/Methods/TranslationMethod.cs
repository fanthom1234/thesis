using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Thesis;

public class TranslationMethod : Method
{
    // one time translate
    public Transform targetPosition;
    public Vector3 offsetTranslate;

    public override IEnumerator Action(BaseClass baseClass)
    {
        targetPosition.Translate(targetPosition.position + offsetTranslate, Space.Self);

        if (!variable.IsReachMax())
            variable.ChangeVariableValue();

        yield return null;
    }

}