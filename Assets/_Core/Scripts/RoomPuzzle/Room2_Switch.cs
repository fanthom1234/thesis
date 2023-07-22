using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Thesis;

public class Room2_Switch : MonoBehaviour
{
    public int numPass;
    public DoorDoubleSlide dds;

    public Renderer targetMat;
    public Material toChangeMat;

    public List<Room2_Switch> listRoom2;
    public bool isLit;

    public void CheckInt(SelectEnterEventArgs obj)
    {
        if (obj.interactable.gameObject.GetComponent<VariableInt>().variableValue == numPass)
        {
            targetMat.material = toChangeMat;
            isLit = true;
            CheckList();
        }
    }

    public void CheckInt(SelectExitEventArgs obj)
    {
        if (obj.interactable.gameObject.GetComponent<VariableInt>().variableValue == numPass)
        {
            isLit = true;
            CheckList();
        }
    }

    public void CheckList()
    {
        foreach(Room2_Switch room in listRoom2)
        {
            if (!room.isLit)
                return;
        }

        dds.Open();
    }
}
