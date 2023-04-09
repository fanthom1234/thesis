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
        public List<Method> _methods;
        public List<VariableType> _variables;
    
        public GameObject variableUIPanel;
        public GameObject methodUIPanel;

        [Header("Time Interval")]
        [SerializeField] private float _nextUpdateOffset = 1f;

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
    
        private void OnCollisionEnter(Collision other) {
            if (other.gameObject.TryGetComponent(out Variable variable))
            {
                if (!_variables.Contains(variable.variableType))
                {
                    _variables.Add(variable.variableType);
                    other.gameObject.SetActive(false);

                    // Invoke variable text holder to update UI panel in baseclass boy
                    variableUIPanel.GetComponent<VariableTextHolder>().updateTextEvent?.Invoke(variable);
                }
            }
    
            if (other.gameObject.TryGetComponent(out Method method))
            {
                StopAllCoroutines();
    
                if (!_methods.Contains(method) && _variables.Contains(method.variableNeeded))
                {
                    _methods.Add(method);
                    
                    other.gameObject.SetActive(false);
                    
                    methodUIPanel.GetComponent<MethodTextHolder>().updateTextEvent?.Invoke(method);

                    if (isMovable)
                        StartExecute();
                }
            }
        }
    
        private IEnumerator ExecuteMethods()
        {
            while (true)
            {
                if (_methods.Count > 0)
                {
                    foreach (Method method in _methods)
                    {
                        method.Action(this.gameObject);

                        Debug.Log(Time.time + " " + method.gameObject.name);
    
                        yield return new WaitForSeconds(_nextUpdateOffset);
                    }
                }
                
                yield return new WaitForSeconds(1f);
                Debug.Log(Time.time);
            }
        }

        public void StartExecute()
        {
            if (isJumpingAtAction)
                transform.DOJump(transform.position, 1, 2, 2f).OnComplete(() => StartCoroutine(ExecuteMethods()));
            else
                StartCoroutine(ExecuteMethods());
        }

        public void StopExecute()
        {
            StopAllCoroutines();
        }
    }
}

