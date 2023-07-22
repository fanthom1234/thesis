using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Thesis;

public class CheckAndDo : MonoBehaviour
{
    // First room
    public DoorDoubleSlide dds;
    public int counter;
    public Renderer targetMat;
    public Material toChangeMat;

    public List<CheckAndDo> checkList;
    public bool isValid;

    public void CheckFirstRoom()
    {
        this.isValid = true;

        foreach (CheckAndDo c in checkList)
        {
            if (c.isValid == false)
                return;
        }
        dds.Open();
        Debug.Log("asdf");
    }

    public void checkVariableBool(SelectExitEventArgs obj)
    {

        if (obj.interactable.gameObject.GetComponent<VariableBool>().variableValue == true)
        {
            // disable grab
            obj.interactable.gameObject.GetComponent<XRGrabInteractable>().enabled = false;

            // change color iris
            targetMat.material = toChangeMat;

            counter++;

            CheckFirstRoom();
        }
    }

    public void checkVariableBool(SelectEnterEventArgs obj)
    {
        if (obj.interactable.gameObject.GetComponent<VariableBool>().variableValue == true)
        {
            // change color iris
            targetMat.material = toChangeMat;

            CheckFirstRoom();
        }
    }
}
