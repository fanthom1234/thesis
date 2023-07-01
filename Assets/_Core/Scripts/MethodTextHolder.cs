using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using Thesis;

[System.Serializable]
public class MethodTextUpdateEvent : UnityEvent<Method> {  }

public class MethodTextHolder : MonoBehaviour
{
    public MethodTextUpdateEvent updateTextEvent;
    // public List<Method> methods;
    public TMP_Text textHolder;

    private void Start() {
        // updateTextEvent?.AddListener(UpdateText);
    }

    public void UpdateText(List<Method> methods)
    {
        ClearText();

        foreach (Method met in methods)
        {
            textHolder.text += "-" + met.methodName + "()\n";
        }
    }

    public void ClearText()
    {
        textHolder.text = "";
    }
}
