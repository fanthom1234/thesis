using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Thesis;
using TMPro;

public class OpenVariableEditPanel : MonoBehaviour
{
    public VariableEditPanel variableEditPanel;
    public TMP_Text  varNameTmpText;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "VariableSphere" && !variableEditPanel.isOpen)
                {
                    variableEditPanel.Open(gameObject.GetComponent<Variable>(), varNameTmpText);
                }
            }
        }
    }
}
