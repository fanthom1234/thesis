using UnityEngine;

namespace Thesis
{
    public class VariableInt : Variable
    {
        public int minValue = 1;
        public int maxValue = 4;
        public int variableValue = 1;
        public bool isIncrease = false;

        public override bool IsReachMax() => variableValue == maxValue;

        public override bool IsReachMin() => variableValue == minValue;

        public override string GetVariableValue()
        {
            return variableValue.ToString(); 
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
            if (variableValue < maxValue)
                variableValue++;
            else 
                variableValue = minValue;
        }

        public override void DecreaseVariableValue()
        {
            if (variableValue > 1)
                variableValue--;
            else 
                variableValue = maxValue;
        }
    }
}
