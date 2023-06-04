using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Thesis
{
    public abstract class Variable : MonoBehaviour
    {
        #region  Properties

        public List<Transform> destinations;
        public Variable overrideVar;
        public Method method;
        public string variableName;
        public List<Variable> affectVariables;
        public bool isPrivate;

        public abstract bool IsReachMax();
        public abstract bool IsReachMin();
        public abstract string GetVariableValue();
        public abstract void IncreaseVariableValue();
        public abstract void DecreaseVariableValue();
        public abstract void ChangeVariableValue();

        #endregion

        private void Start() {
            variableName = gameObject.name;
        }

        #region  OnCollisionEnter

        private void OnCollisionEnter(Collision other) {
            if (other.gameObject.TryGetComponent(out Method method1))
            {
                if (this.method != null)
                    return;

                this.method = method1;
            }

            if (other.gameObject.TryGetComponent(out BaseClass baseClass))
            {
                baseClass.StopExecute();

                if (baseClass.variables.Any(var => var.variableName == this.variableName))
                {
                    this.gameObject.SetActive(false);
                    return;
                }

                if (overrideVar != null && baseClass.variables.Any(var => var.variableName == overrideVar.variableName))
                {
                    for (int i = 0; i < baseClass.variables.Count; i++)
                    {
                        if (baseClass.variables[i].variableName == overrideVar.variableName)
                        {
                            baseClass.variables.RemoveAt(i);
                            i--;
                            baseClass.UpdatePanel();
                        }
                    }

                    foreach (Method method in baseClass.methods)
                    {
                        if (method.variable != null && this.method.methodName == method.methodName)
                        {
                            method.variable = this;
                        }
                    }
                }

                // add variable to base class
                baseClass.variables.Add(this);

                // update base_class's variable panel 
                baseClass.UpdatePanel();
                
                // this.gameObject.SetActive(false);
                this.gameObject.transform.position = baseClass.afterMergeClassTF.position;

                // baseClass.StartExecute();
            }
        }

        #endregion
    }
}
