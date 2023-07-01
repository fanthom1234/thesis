using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Thesis;
using TMPro;

public class ClassEditPanel : MonoBehaviour
{
    public bool isPauseTime = true;
    public bool isOpen;
    public TMP_InputField inputField;
    private TMP_Text classTmpText;
    public BaseClass baseClass;

    public void Open(BaseClass baseClass, TMP_Text classNameText)
    {
        classTmpText = classNameText;
        this.baseClass = baseClass;
        gameObject.SetActive(true);
        // transform to spawn in each mentor
        if (isPauseTime)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        isOpen = true;
    }

    public void Close()
    {
        gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        Cursor.visible = false;
        isOpen = false;
    }

    public void UpdateClassName()
    {
        baseClass.className = inputField.text;
        classTmpText.text = inputField.text;
        Close();
    }

    public void CreateObject()
    {
        GameObject copiedObject = GameObject.Instantiate(this.baseClass.gameObject, transform.position, Quaternion.identity);
        Vector3 newPosition = this.baseClass.transform.position + new Vector3(0f, 0f, -2f);
        copiedObject.transform.position = newPosition;
        copiedObject.transform.SetParent(this.baseClass.transform.parent);
        Close();
    }
}
