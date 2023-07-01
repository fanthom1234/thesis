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
    
        public VariableType variableType;
        public Variable variable;
        public string methodName;
        public TMP_Text methodNameUI;
        public GameObject lineRenderer_glow;
        public abstract IEnumerator Action(BaseClass baseClass);
        protected GameObject baseClassGO;

        #endregion
    
        private void Start() {
            methodName = gameObject.name;
        }

        #region OnCollisionEnter
    
        protected virtual void OnTriggerEnter(Collider other) {
            if (other.gameObject.TryGetComponent(out Variable variable))
            {
                if (this.variable != null)
                    return;

                this.variable = variable;
                methodNameUI.text += " *";
            }

            if (other.gameObject.TryGetComponent(out BaseClass baseClass))
            {
                if (this.variable == null)
                    return;

                baseClass.StopExecute();

                // Get gameobject for method action
                baseClassGO = baseClass.gameObject;

                // if (!baseClass.variables.Any(var => var == this.variable))
                //     return;

                // foreach (var var in baseClass.variables)
                // {
                //     if (var.variableName == variable.variableName)
                //         variable = var;
                // }
                    
                // add method's variable
                if (baseClass.variables.Count == 0)
                {
                    // this.gameObject.SetActive(false);
                    baseClass.variables.Add(this.variable);
                }
                else if (baseClass.variables.Count > 0 && 
                        !baseClass.variables.Any(var => (var.variableName == this.variable.variableName))) 
                {
                    baseClass.variables.Add(this.variable);
                }
                

                if (baseClass.methods.Any(method => method == this)) 
                {
                    // this.gameObject.SetActive(false);
                    return;
                }

                baseClass.methods.Add(this);

                this.gameObject.transform.parent = baseClass.transform;
                this.variable.transform.parent = baseClass.transform;

                baseClass.UpdatePanel();
    
                GameObject lr = GameObject.Instantiate(lineRenderer_glow, transform.position, Quaternion.identity);
                lr.GetComponent<LinkLineBehav>().SetLinePoints(gameObject.transform, baseClass.transform);
                lr.SetActive(true);

                // this.gameObject.SetActive(false);

                // baseClass.StartExecute();
            }
        }
    
        #endregion
    }
}

