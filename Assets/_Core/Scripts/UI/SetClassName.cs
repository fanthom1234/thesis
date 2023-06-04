using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Thesis;

public class SetClassName : MonoBehaviour
{
    public TMP_Text text;

    private void Start() {
        // UpdateText("obj");
        BaseClass parent = GetComponentInParent<BaseClass>();
        text.text = parent.className;
    }

    public void UpdateText(string className) 
    {
        text.text = className;
    }
}
