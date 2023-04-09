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

    // private List<GameObject> _textToUse;
    public GameObject textUITemplate;

    private void Start() {
        updateTextEvent?.AddListener(UpdateText);
    }

    public void UpdateText(Method method)
    {
        // im too lazy to make get mothods so, eiei
        GameObject newText = GameObject.Instantiate(textUITemplate, transform);
        newText.GetComponent<TMP_Text>().text = method.gameObject.name;
    }
}
