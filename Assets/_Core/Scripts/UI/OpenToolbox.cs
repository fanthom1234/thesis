using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Thesis;

public class OpenToolbox : MonoBehaviour
{
    public ToolboxPanel toolboxPanel;
    // instantiate point for each mentor
    public Transform spawnSphere;

    private void Update() {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "mentor" && !toolboxPanel.isOpen)
                {
                    Debug.Log("ayo");
                    toolboxPanel.Open(this);
                }
            }
        }
    }

    public void OpenToolBoxPanel()
    {
        this.toolboxPanel.Open(this);
    }
}
