using UnityEngine;
using Thesis;
using System.Linq;

namespace Thesis
{
    public abstract class Method : MonoBehaviour
    {
        // public abstract Transform targetTF { get; }
        // public abstract float actingDuration { get; }
        // public abstract VariableType variableNeeded { get; }
        // public abstract void Action(GameObject from);
        #region Properties
    
        public Variable variable;
        public string methodName => gameObject.name;
        public abstract void Action(BaseClass baseClass);
    
        #endregion
    
        #region OnCollisionEnter
    
        private void OnCollisionEnter(Collision other) {
            if (other.gameObject.TryGetComponent(out BaseClass baseClass))
            {
                if (!baseClass.variables.Any(var => var.variableName == variable.variableName))
                    return;

                foreach (var var in baseClass.variables)
                {
                    if (var.variableName == variable.variableName)
                        variable = var;
                }
                    
    
                if (baseClass.methods.Any(method => method.methodName == this.methodName)) 
                {
                    this.gameObject.SetActive(false);
                    return;
                }

                baseClass.methods.Add(this);

                baseClass.methodUIPanel.GetComponent<MethodTextHolder>().updateTextEvent?.Invoke(this);
    
                this.gameObject.SetActive(false);
            }
        }
    
        #endregion
    }
}

