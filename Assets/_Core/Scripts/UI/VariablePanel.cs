using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Thesis
{
    public class VariablePanel : MonoBehaviour
    {
        public static bool isOpen = false;
        public BaseClass baseClass;
        public GameObject variableInputTemplate;
        public Transform parentTF;

        public void Open(BaseClass baseClass)
        {
            this.baseClass = baseClass;
            gameObject.SetActive(true);
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            isOpen = true;
            Refresh(baseClass);
        }

        public void Close()
        {
            baseClass.variableUIPanel.UpdateText();
            gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
            Cursor.visible = false;
            isOpen = false;
        }

        public void Refresh(BaseClass baseClass)
        {
            foreach (Transform child in parentTF) {
                GameObject.Destroy(child.gameObject);
            }

            foreach (Variable variable in baseClass.variables)
            {
                GameObject newVarUI = GameObject.Instantiate(variableInputTemplate, parentTF);
                newVarUI.SetActive(true);
                newVarUI.GetComponentInChildren<TMP_Text>().text = variable.variableName + ": " + variable.GetVariableValue();
                newVarUI.transform.Find("IncreaseButton").GetComponent<Button>().onClick.AddListener(() => {
                    variable.IncreaseVariableValue();
                    Debug.Log("Inc");
                    Refresh(baseClass);
                });
                newVarUI.transform.Find("DecreaseButton").GetComponent<Button>().onClick.AddListener(() => {
                    variable.DecreaseVariableValue();
                    Refresh(baseClass);
                });
            }
        }
    }
}

