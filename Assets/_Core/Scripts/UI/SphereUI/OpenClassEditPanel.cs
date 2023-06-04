using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Thesis;
using TMPro;

public class OpenClassEditPanel : MonoBehaviour
{
    public ClassEditPanel classEditPanel;
    public TMP_Text  classNameText;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "ClassSphere" && !classEditPanel.isOpen)
                {
                    classEditPanel.Open(gameObject.GetComponent<BaseClass>(), classNameText);
                }
            }
        }
    }
}
