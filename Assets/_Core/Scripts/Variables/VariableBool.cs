using UnityEngine;

namespace Thesis
{
    public class VariableBool : Variable
    {
        private bool _variableValue;

        public override bool IsReachMax() => _variableValue == true;

        public override string GetVariableValue()
        {
            return _variableValue.ToString();
        }

        public override void ChangeVariableValue()
        {
            _variableValue = !_variableValue;
        }
    }
}
