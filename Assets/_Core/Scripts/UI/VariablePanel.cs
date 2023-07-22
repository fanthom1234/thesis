using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Thesis
{
    public class VariablePanel : MonoBehaviour
    {
        public bool isPauseTime = true;

        public static bool isOpen = false;
        public BaseClass baseClass;

        public GameObject variableInputTemplate;
        public GameObject methodInputTemplate;
        public GameObject privateVariableInputTemplate;

        public Button showBut;
        public Button hideBut;

        public bool openWhenStart = false;

        public Transform parentTF;

        // Class name input field
        public TMP_InputField inputField;

        private TMP_Text classTmpText;

        public void Start()
        {
            if (openWhenStart && baseClass != null)
            {
                Open(this.baseClass, classTmpText);
            }
        }

        public void Open(BaseClass baseClass, TMP_Text tMP_Text)
        {
            // if (baseClass.variables.Count == 0)
            //     return;
                
            this.classTmpText = tMP_Text;

            if (showBut != null)
            {
                showBut.onClick.RemoveAllListeners();
                showBut.onClick.AddListener(baseClass.ShowBalls);
            }

            if (hideBut != null)
            {
                hideBut.onClick.RemoveAllListeners();
                hideBut.onClick.AddListener(baseClass.HideBalls);
            }


            this.baseClass = baseClass;
            gameObject.SetActive(true);
            if (isPauseTime)
                Time.timeScale = 0;
            else
                Time.timeScale = 1;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            isOpen = true;
            Refresh(baseClass);
        }

        public void Close()
        {
            baseClass.UpdatePanel();
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
                if (!variable.isPrivate)
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
                else
                {
                    GameObject newVarUI = GameObject.Instantiate(privateVariableInputTemplate, parentTF);
                    newVarUI.SetActive(true);
                    newVarUI.GetComponentInChildren<TMP_Text>().text = variable.variableName + ": " + variable.GetVariableValue();
                }
            }

            foreach (Method method in baseClass.methods)
            {
                GameObject newMethodUI = GameObject.Instantiate(methodInputTemplate, parentTF);
                newMethodUI.SetActive(true);
                newMethodUI.GetComponentInChildren<TMP_Text>().text = method.methodName + "()";
                newMethodUI.transform.Find("ExecuteButton").GetComponent<Button>().onClick.AddListener(() => {
                    Debug.Log("Execute pressed");
                    StartCoroutine(method.Action(baseClass));
                    Refresh(baseClass);
                    Close();
                });
            }
        }

    public void UpdateClassName()
    {
        this.baseClass.className = inputField.text;
        classTmpText.text = inputField.text;
        Close();
    }

    public void CreateObject()
    {
        GameObject copiedObject = GameObject.Instantiate(this.baseClass.gameObject, transform.position, Quaternion.identity);
        Vector3 newPosition = this.baseClass.transform.position + new Vector3(0f, 0f, -2f);
        copiedObject.transform.position = newPosition;
        copiedObject.transform.SetParent(this.baseClass.transform.parent);
        copiedObject.GetComponent<Drag>()._canDrag = true;
        Close();
    }
    }
}

