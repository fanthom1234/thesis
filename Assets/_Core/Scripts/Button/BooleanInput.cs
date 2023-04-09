using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BooleanInput : MonoBehaviour
{
    [SerializeField] private UnityEvent onClickButton;

    [SerializeField] private Renderer buttonColor;
    [SerializeField] private Material pressedColor;

    private Material defaultColor;
    private bool isPressed;
    private Collider _collider;

    private void Awake() {
        defaultColor = gameObject.GetComponent<Material>();
    }

    private void Start() {
        _collider = GetComponent<Collider>();
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0) && _collider.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 100f))
        {
            isPressed = !isPressed;

            // Change color
            if (isPressed)
                buttonColor.material.SetColor("_Color", Color.red);
            else
                gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.white);

            onClickButton?.Invoke();
        }
    }
}
