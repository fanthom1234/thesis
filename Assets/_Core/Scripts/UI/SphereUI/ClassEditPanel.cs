using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Thesis;
using TMPro;

public class ClassEditPanel : MonoBehaviour
{
    public bool isOpen;
    public TMP_InputField inputField;
    public TMP_Text classTmpText;
    private BaseClass baseClass;

    public void Open(BaseClass baseClass, TMP_Text classNameText)
    {
        classTmpText = classNameText;
        this.baseClass = baseClass;
        gameObject.SetActive(true);
        // transform to spawn in each mentor
        Time.timeScale = 0;
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
}
