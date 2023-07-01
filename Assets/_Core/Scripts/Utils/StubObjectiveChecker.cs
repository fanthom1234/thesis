using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObjectiveManagerandQuestEngine;
using Thesis;

public class StubObjectiveChecker : MonoBehaviour
{
    [Header("Required")]
    // public string className;
    public List<VariableType> variablesType;
    public List<string> methodsName;
    public GameObject rewardObj;

    public string Name;
    public ObjectiveType ObjectiveType;
    [ShowWhen("ObjectiveType", ObjectiveType.Count)]
    public CountType countType;
    private float LastTimeCheck = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out BaseClass baseClass))
        {
            foreach (Method method in baseClass.methods)
            {
                if (!methodsName.Contains(method.methodName.ToLower()))
                    return;
            }
        Debug.Log("yo");

            foreach (Variable var in baseClass.variables)
            {
                if (!variablesType.Contains(var.variableType))
                    return;
            }

            if (ObjectiveType == ObjectiveType.Count && countType == CountType.Collected)
            {
                Collected();
                other.gameObject.GetComponent<Drag>()._canDrag = false;
                other.gameObject.GetComponent<SphereCollider>().radius = 1f;
            }
        }
    }

    public void Collected()
    {
        var result = ObjectiveManager.instance.CheckObjectiveStatus(Name, ObjectiveType.Count);
        if(result) Destroy(gameObject);
    }
}
