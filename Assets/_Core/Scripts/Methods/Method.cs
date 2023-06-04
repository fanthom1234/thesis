using System.Collections;
using UnityEngine;
using Thesis;
using System.Linq;
using TMPro;

namespace Thesis
{
    public abstract class Method : MonoBehaviour
    {
        #region Properties
    
        public Variable variable;
        public string methodName;
        public TMP_Text methodNameUI;
        public abstract IEnumerator Action(BaseClass baseClass);
        protected GameObject baseClassGO;

        #endregion
    
        private void Start() {
            methodName = gameObject.name;
        }

        #region OnCollisionEnter
    
        protected virtual void OnCollisionEnter(Collision other) {
            if (other.gameObject.TryGetComponent(out Variable variable))
            {
                if (this.variable != null)
                    return;

                this.variable = variable;
                methodNameUI.text += " *";
            }

            if (other.gameObject.TryGetComponent(out BaseClass baseClass))
            {
                baseClass.StopExecute();

                // Get gameobject for method action
                baseClassGO = baseClass.gameObject;

                if (!baseClass.variables.Any(var => var == this.variable))
                    return;

                // foreach (var var in baseClass.variables)
                // {
                //     if (var.variableName == variable.variableName)
                //         variable = var;
                // }
                    
    
                if (baseClass.methods.Any(method => method == this)) 
                {
                    // this.gameObject.SetActive(false);
                    return;
                }

                baseClass.methods.Add(this);

                baseClass.UpdatePanel();
    
                // this.gameObject.SetActive(false);
                this.gameObject.transform.position = baseClass.afterMergeClassTF.position;

                // baseClass.StartExecute();
            }
        }
    
        #endregion
    }
}

