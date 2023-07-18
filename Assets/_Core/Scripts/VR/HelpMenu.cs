using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HelpMenu : MonoBehaviour
{
    [SerializeField] private InputActionReference menuInputActionReference;

    public bool isOpen = true;
    public GameObject tutPanel;

    
    private void OnEnable()
    {
        menuInputActionReference.action.started += MenuPressed;
    }
    
    private void OnDisable()
    {
        menuInputActionReference.action.started -= MenuPressed;
    
    }
    
    public void MenuPressed(InputAction.CallbackContext context)
    {
        Debug.Log("MenuPressed!");
        tutPanel.SetActive(!isOpen);
        isOpen = !isOpen;


    }
   

}
