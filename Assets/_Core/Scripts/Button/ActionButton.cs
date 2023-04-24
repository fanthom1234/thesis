using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Thesis;

public class ActionButton : MonoBehaviour
{
    public BaseClass baseClass;
    private Collider _collider;

    private void Start() {
        _collider = GetComponent<Collider>();
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0) && _collider.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 100f))
        {
            baseClass.StartExecute();
        }
    }
}
