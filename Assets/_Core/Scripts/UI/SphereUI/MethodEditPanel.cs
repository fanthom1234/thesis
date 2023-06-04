using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Thesis;
using TMPro;
using System;

public class MethodEditPanel : MonoBehaviour
{
    public bool isOpen;

    // Change name
    public TMP_InputField inputField;
    private TMP_Text varTmpText;
    // Change method
    public TMP_Dropdown dropdownUI;
    public Int32 chosenVarIndex;
    public List<Method> methods;

    public MethodAction baseMethod;

    public void Open(MethodAction method, TMP_Text tMP_Text)
    {
        varTmpText = tMP_Text;
        this.baseMethod = method;
        gameObject.SetActive(true);
        // transform to spawn in each mentor
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
    
    public void UpdateMethodName()
    {
        baseMethod.methodName = inputField.text;
        varTmpText.text = "Method: " + inputField.text;
        Close();
    }

    public void UpdateMethodAction()
    {
        baseMethod.methodName = methods[chosenVarIndex].methodName;
        baseMethod.currentMethod = methods[chosenVarIndex];
        varTmpText.text = "Method: " + methods[chosenVarIndex].methodName;
        Close();
    }

    public void OnDropDownChange(Int32 index)
    {
        chosenVarIndex = index;
    }
}
