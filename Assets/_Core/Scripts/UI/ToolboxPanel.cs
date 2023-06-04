using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Thesis;

public class ToolboxPanel : MonoBehaviour
{
    // public InputField inputField;
    public string classInputText = "ayo";

    [Header("Dropdown")]
    public TMP_Dropdown dropdownUI;
    public Int32 chosenVarIndex;

    [Header("Templates and spawnTF")]
    public GameObject classSphereTemplate;
    public List<GameObject> variableSphereTemplate; // int color graphic
    public GameObject methodSphereTemplate;
    public Transform parentTF;

    public bool isOpen;

    private void Start() {
        // inputField.onEndEdit.AddListener(OnInputEndEdit);
    }

    // Handler for dropdown GO
    public void OnDropDownChange(Int32 index)
    {
        chosenVarIndex = index;
    }

    // pass mentor gameobject to function
    // main func is to get spawn point
    public void Open(OpenToolbox tb)
    {
        gameObject.SetActive(true);
        // transform to spawn in each mentor
        parentTF = tb.spawnSphere;
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        isOpen = true;
    }

    public void Close()
    {
        gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        Cursor.visible = false;
        isOpen = false;
    }

    public void CreateClassSphere()
    {
        GameObject classSphereGO = GameObject.Instantiate(classSphereTemplate, parentTF);
        classSphereGO.SetActive(true);
        classSphereGO.transform.position = parentTF.position;
        // classSphereGO.GetComponentInChildren<SetClassName>().UpdateText(classInputText);
        classSphereGO.name = classSphereGO.name.Replace("(Clone)", "");
        Close();
    }

    public void CreateVariableSphere()
    {
        GameObject variableSphereGO = GameObject.Instantiate(variableSphereTemplate[chosenVarIndex], parentTF);
        variableSphereGO.SetActive(true);
        variableSphereGO.transform.position = parentTF.position;
        variableSphereGO.name = variableSphereGO.name.Replace("(Clone)", "");
        Close();
    }

    public void CreateMethodSphere()
    {
        GameObject methodSphereGO = GameObject.Instantiate(methodSphereTemplate, parentTF);
        methodSphereGO.SetActive(true);
        methodSphereGO.transform.position = parentTF.position;
        methodSphereGO.name = methodSphereGO.name.Replace("(Clone)", "");
        Close();
    }

    private void OnInputEndEdit(string inputClassText)
    {
        classInputText = inputClassText;
    }
}
