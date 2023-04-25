using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Thesis
{
    public class BaseClass : MonoBehaviour
    {
        #region Variable
    
        [Header("Required")]
        public bool isMovable = true;

        [Header("Methods & Variables")]
        public List<Method> methods;
        public List<Variable> variables;
    
        public VariableTextHolder variableUIPanel;
        public MethodTextHolder methodUIPanel;

        [Header("Time Interval")]
        [SerializeField] private float _nextUpdateOffset = 3f;

        [Header("Setting")]
        [SerializeField] private bool isJumpingAtAction = false;
    
        #endregion
    
        private void Start() {
            Cursor.lockState = CursorLockMode.Locked;
        }
    
        #region OnEnable/OnDisable

        private void OnEnable() {
            StartExecute();
        }

        private void OnDisable() {
            if (isMovable)
                StopExecute();
        }

        #endregion
    
        private IEnumerator ExecuteMethods()
        {
            bool did = false;
            while (!did)
            {
                if (methods.Count > 0)
                {
                    foreach (Method method in methods)
                    {
                        while(true)
                        {
                            StartCoroutine(method.Action(this));
                            yield return new WaitForSeconds(_nextUpdateOffset);
                            method.variable.ChangeVariableValue();
                            variableUIPanel.UpdateText();

                            if (method.variable.IsReachMax() || method.variable.IsReachMin())
                                break;
                        }
                        Debug.Log("Done");
                    }
                }
                
                yield return new WaitForSeconds(1f);
                // Debug.Log(Time.time);
                did = true;
            }
        }

        public void StartExecute()
        {
            if (isJumpingAtAction)
                StartCoroutine(ExecuteMethods());
            else
                StartCoroutine(ExecuteMethods());
        }

        public void StopExecute()
        {
            StopAllCoroutines();
        }
    }
}

