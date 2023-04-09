using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using Thesis;

[System.Serializable]
public class VariableTextUpdateEvent : UnityEvent<Variable> {  }

public class VariableTextHolder : MonoBehaviour
{
    public VariableTextUpdateEvent updateTextEvent;

    // private List<GameObject> _textToUse;
    public GameObject textUITemplate;

    private void Start() {
        updateTextEvent?.AddListener(UpdateText);
    }

    public void UpdateText(Variable variable)
    {
        // im too lazy to make get mothods so, eiei
        GameObject newText = GameObject.Instantiate(textUITemplate, transform);
        newText.GetComponent<TMP_Text>().text = variable.gameObject.GetComponentInChildren<TMP_Text>().text;
    }
}
