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
        public string className = "object";
        public Transform hideBallsTF;
        public Transform showBallsTF;

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

            UpdatePanel();
        }
    
        #region OnEnable/OnDisable

        private void OnEnable() {
            // gameObject.transform.DOJump(gameObject.transform.position, 1, 2, 2f);

            // StartExecute();
        }

        private void OnDisable() {
            if (isMovable)
                StopExecute();
        }

        #endregion
    
        private IEnumerator ExecuteMethods()
        {
            while (true && isMovable)
            {
                if (methods.Count > 0)
                {
                    foreach (Method method in methods)
                    {
                        // gameObject.transform.DOJump(gameObject.transform.position, 1, 2, 2f);

                        while(true)
                        {
                            StartCoroutine(method.Action(this));
                            yield return new WaitForSeconds(_nextUpdateOffset);
                            method.variable.ChangeVariableValue();
                            UpdatePanel();

                            if (method.variable.IsReachMax() || method.variable.IsReachMin())
                                break;
                        }
                        Debug.Log("Done");
                    }
                }
                
                yield return new WaitForSeconds(1f);
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

        public void UpdatePanel()
        {
            if (variables.Count > 0)
            {
                foreach (Variable var in variables)
                {
                    variableUIPanel?.UpdateText(variables);
                }
            }

            if (methods.Count > 0)
            {
                foreach (Method method in methods)
                {
                    methodUIPanel?.UpdateText(methods);
                }
            }
        }

        public void HideBalls()
        {
            //foreach (Method method in methods)
            //{
            //    method.gameObject.transform.position = hideBallsTF.position;
            //}

            //foreach (Variable var in variables)
            //{
            //    var.gameObject.transform.position = hideBallsTF.position;
            //}
            foreach (Method method in methods)
            {
                method.gameObject.SetActive(false);
            }

            foreach (Variable var in variables)
            {
                var.gameObject.SetActive(false);
            }
        }

        public void ShowBalls()
        {
            //foreach (Method method in methods)
            //{
            //    method.gameObject.transform.position = showBallsTF.position;
            //}

            //foreach (Variable var in variables)
            //{
            //    var.gameObject.transform.position = showBallsTF.position;
            //}
            foreach (Method method in methods)
            {
                method.gameObject.SetActive(true);
            }

            foreach (Variable var in variables)
            {
                var.gameObject.SetActive(true);
            }
        }
    }
}

