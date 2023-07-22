using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Thesis;

public class EnableWhenSocket : MonoBehaviour
{
    public GameObject go;

    public Renderer targetMat;
    public Material toChangeMat;

    public void EnableGO(SelectExitEventArgs obj)
    {
        if (obj.interactable.gameObject.GetComponent<VariableBool>().variableValue == true)
        {
            go.SetActive(true);
        }
    }

    public void EnableGO(SelectEnterEventArgs obj)
    {
        if (obj.interactable.gameObject.GetComponent<VariableBool>().variableValue == true)
        {
            targetMat.material = toChangeMat;
            go.SetActive(true);
        }
    }

}
