using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using Thesis;

[System.Serializable]
public class VariableTextUpdateEvent : UnityEvent<Variable> {  }

public class VariableTextHolder : MonoBehaviour
{
    public VariableTextUpdateEvent updateTextEvent;
    public List<Variable> variables;
    public TMP_Text textHolder;

    private void Awake() {
        updateTextEvent?.AddListener(UpdateText);
    }

    public void UpdateText()
    {
        ClearText();

        foreach (Variable var in variables)
        {
            textHolder.text += "\n" + var.variableName + ": " + var.GetVariableValue();
        }
    }

    public void UpdateText(Variable variable)
    {
        if (variable != null && !variables.Contains(variable))
            variables.Add(variable);

        ClearText();

        foreach (Variable var in variables)
        {
            textHolder.text += "\n" + var.variableName + ": " + var.GetVariableValue();
        }
    }

    public void ClearText()
    {
        textHolder.text = "";
    }
}
