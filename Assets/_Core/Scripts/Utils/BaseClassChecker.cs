using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Thesis;
using System;

// For mentor to check if given baseclass is correct or not
// then will trigger quizz pass
public class BaseClassChecker : MonoBehaviour
{
    [Header("Required")]
    // public string className;
    public List<VariableType> variablesType;
    public List<string> methodsName;
    public GameObject rewardObj;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.TryGetComponent(out BaseClass baseClass))
        {
            // Debug.Log(baseClass.className.ToLower());
            // if (baseClass.className.ToLower() != className)
            //     return;

            foreach (Method method in baseClass.methods)
            {
                if (!methodsName.Contains(method.methodName.ToLower()))
                    return;
            }

            foreach (Variable var in baseClass.variables)
            {
                if (!variablesType.Contains(var.variableType))
                    return;
            }

            Debug.Log("Grat!!");
            // trigger quizz
            rewardObj.SetActive(true);
        }
    }
}
