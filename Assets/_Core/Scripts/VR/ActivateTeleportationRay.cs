using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActivateTeleportationRay : MonoBehaviour
{
    public GameObject leftTele;
    public GameObject rightTele;

    public InputActionProperty leftAct;
    public InputActionProperty rightAct;

    private void Update() {
        leftTele.SetActive(leftAct.action.ReadValue<float>() > 0.1f);
        rightTele.SetActive(rightAct.action.ReadValue<float>() > 0.1f);
    }
}
