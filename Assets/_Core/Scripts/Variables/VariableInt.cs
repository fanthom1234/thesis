using UnityEngine;

namespace Thesis
{
    public class VariableInt : Variable
    {
        [Range(1, 4)]
        private int _variableValue = 1;

        public override bool IsReachMax() => _variableValue == 4;

        public override string GetVariableValue()
        {
            return _variableValue.ToString(); 
        }

        public override void ChangeVariableValue()
        {
            if (_variableValue < 4)
                _variableValue++;
            else 
                _variableValue = 1;
        }
    }

}
