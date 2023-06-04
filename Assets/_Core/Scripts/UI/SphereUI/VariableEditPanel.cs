using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Thesis;
using TMPro;

public class VariableEditPanel : MonoBehaviour
{
    public bool isOpen;
    // Change name
    public TMP_InputField inputField;
    public TMP_Text varTmpText;
    // Change value
    public TMP_InputField inputField_val;
    public TMP_Text varTmpText_val;

    private Variable baseVariable;

    public void Open(Variable baseVariable, TMP_Text varNameText)
    {
        varTmpText = varNameText;
        this.baseVariable = baseVariable;
        UpdateVariableValue();
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

    public void UpdateVariableValue()
    {
        inputField_val.text = baseVariable.GetVariableValue();
    }

    public void UpdateVariableName()
    {
        baseVariable.variableName = inputField.text;
        varTmpText.text = "variable: " + inputField.text;
        UpdateVariableValue();
    }

    public void IncreaseVariableValue()
    {
        baseVariable.IncreaseVariableValue();
        UpdateVariableValue();
    }

    public void DecreaseVariableValue()
    {
        baseVariable.DecreaseVariableValue();
        UpdateVariableValue();
    }
}
