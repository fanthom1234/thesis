using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Thesis;

public class AddFunctionButton : MonoBehaviour
{   
    [SerializeField] private BaseClass targetObject;
    // [SerializeField] private BaseMethod baseMethod;

    private Collider _collider;
    private bool isAdded = false;

    private void Start() {
        _collider = GetComponent<Collider>();
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0) && _collider.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 100f))
        {
            if (isAdded)
                return;

            isAdded = true;

            // targetObject._methods.Add(baseMethod);
            targetObject.StopExecute();
            targetObject.StartExecute();
        }
    }
}
