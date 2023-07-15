using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toolbox : MonoBehaviour
{
    public Transform instantiateTF;

    public GameObject classTemplateGO;
    public GameObject methodTemplateGO;
    public GameObject variableTemplateGo;


    public GameObject spheres;
    private bool isToolboxOpen;

    public void InteractToolBox()
    {
        spheres.SetActive(!isToolboxOpen);
        isToolboxOpen = !isToolboxOpen;
    }

    public void InteractClassModel()
    {
        GameObject.Instantiate(classTemplateGO, instantiateTF.position, Quaternion.identity);
    }

    public void InteractMethodModel()
    {
        GameObject.Instantiate(methodTemplateGO, instantiateTF.position, Quaternion.identity);
    }

    public void InteractVariableModel()
    {
        GameObject.Instantiate(variableTemplateGo, instantiateTF.position, Quaternion.identity);
    }
}
