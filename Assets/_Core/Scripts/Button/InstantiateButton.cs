using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

            onClickButton?.Invoke();
            Debug.Log("skadi");
        }
    }
}
