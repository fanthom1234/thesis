using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using Thesis;

public class InstantiateButton : MonoBehaviour
{
    [SerializeField] private GameObject spawnGO;
    [SerializeField] private UnityEvent onClickButton;
    [SerializeField] private Transform spawnPos;

    private Collider _collider;

    private void Start() {
        _collider = GetComponent<Collider>();
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0) && _collider.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 100f))
        {
            // Instantiate
            GameObject newGameObject = GameObject.Instantiate(spawnGO, spawnPos.position, spawnPos.rotation);
            newGameObject.GetComponent<Drag>().SetDrag(true);
            newGameObject.GetComponent<Rigidbody>().isKinematic = false;
            newGameObject.GetComponent<BaseClass>().isMovable = true;
            // List<Method> methods = newGameObject.GetComponent<BaseClass>().methods;
            // List<Method> newMethod = new List<Method>();
            // foreach (Method met in methods)
            // {
            //     Method tmpMed = Method.Instantiate(met, transform);
            //     newMethod.Add(tmpMed);
            // }

            // methods.Clear();

            // foreach (Method met in newMethod)
            // {
            //     methods.Add(met);
            // }

            onClickButton?.Invoke();
        }
    }
}
