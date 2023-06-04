using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Thesis;
using TMPro;

public class OpenMethodEditPanel : MonoBehaviour
{
    public MethodEditPanel methodEditPanel;
    public TMP_Text  methNameTmpText;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "MethodSphere" && !methodEditPanel.isOpen)
                {
                    methodEditPanel.Open(gameObject.GetComponent<MethodAction>(), methNameTmpText);
                }
            }
        }
    }
}
