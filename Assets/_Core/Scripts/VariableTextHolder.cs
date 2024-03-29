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
    public TMP_Text textHolder;

    private void Awake() {
        // updateTextEvent?.AddListener(UpdateText);
    }

    public void UpdateText(List<Variable> variables)
    {
        ClearText();

        if (variables.Count > 0)
        {
            foreach (Variable var in variables)
            {
                if (var.variableName.Contains("VariableSphere"))
                {
                    string[] split = var.variableName.Split();
                    textHolder.text += "-" + split[1] + ": " + var.GetVariableValue() + "\n";
                }
                
                textHolder.text += "-" + var.variableName + ": " + var.GetVariableValue() + "\n";
            }
        }
    }

    public void ClearText()
    {
        textHolder.text = "";
    }
}
