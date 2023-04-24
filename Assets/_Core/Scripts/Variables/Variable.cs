using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Thesis
{
    public enum VariableType {
            Hungriness = 0,
            Tiredness = 1,
            Wealthiness = 2,
    }

    public abstract class Variable : MonoBehaviour
    {
        #region  Properties

        public string variableName => gameObject.name;
        public Variable[] affectVariables;

        public abstract bool IsReachMax();
        public abstract string GetVariableValue();
        public abstract void ChangeVariableValue();

        #endregion

        #region  OnCollisionEnter

        private void OnCollisionEnter(Collision other) {
            if (other.gameObject.TryGetComponent(out BaseClass baseClass))
            {
                if (baseClass.variables.Any(var => var.variableName == this.variableName))
                {
                    this.gameObject.SetActive(false);
                    return;
                }

                // add variable to base class
                baseClass.variables.Add(this);

                // update base_class's variable panel 
                baseClass.variableUIPanel.updateTextEvent?.Invoke(this);
                
                this.gameObject.SetActive(false);
            }
        }

        #endregion
    }
}
