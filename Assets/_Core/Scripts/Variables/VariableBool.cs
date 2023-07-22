using UnityEngine;

namespace Thesis
{
    public class VariableBool : Variable
    {
        public bool variableValue;

        public override bool IsReachMax() => variableValue == true;

        public override bool IsReachMin() => variableValue == false;

        public override string GetVariableValue()
        {
            return variableValue.ToString();
        }

        public override void ChangeVariableValue()
        {
            variableValue = !variableValue;

            if (affectVariables.Count > 0)
            {
                foreach (Variable variable in affectVariables)
                {
                    variable.ChangeVariableValue();
                }
            }
        }

        public override void IncreaseVariableValue()
        {
            variableValue = !variableValue;
        }

        public override void DecreaseVariableValue()
        {
            variableValue = !variableValue;

        }
    }
}
