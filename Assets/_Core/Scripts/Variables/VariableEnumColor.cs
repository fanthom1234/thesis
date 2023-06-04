using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Thesis;

public class VariableEnumColor : Variable
{
    // Enum String

    public Renderer targetRenderer;
    public Material[] presetMaterials;
    private int materialIndex;
    
    public bool isIncrease = false;
    public override bool IsReachMax() => materialIndex == presetMaterials.Length - 1;
    public override bool IsReachMin() => materialIndex == 0;
    public override string GetVariableValue()
    {
        return presetMaterials[materialIndex].name.ToString(); 
    }
    public override void ChangeVariableValue()
    {
        if (affectVariables.Count > 0)
        {
            foreach (Variable variable in affectVariables)
            {
                variable.ChangeVariableValue();
            }
        }
        
        if (isIncrease)
            IncreaseVariableValue();
        else
            DecreaseVariableValue();
    }
    public override void IncreaseVariableValue()
    {
        if (targetRenderer != null)
        {
            if (materialIndex < presetMaterials.Length - 1)
            {
                materialIndex++;
                targetRenderer.material = presetMaterials[materialIndex];
            }
            if (materialIndex >= presetMaterials.Length)
                materialIndex = 0;
        }
    }
    public override void DecreaseVariableValue()
    {
        if (targetRenderer != null)
        {
            if (materialIndex <= presetMaterials.Length)
            {
                materialIndex--;
                targetRenderer.material = presetMaterials[materialIndex];
            }
            if (materialIndex <= 0)
                materialIndex = 0;
        }
    }
}
