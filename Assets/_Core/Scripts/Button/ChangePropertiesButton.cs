using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class ChangePropertiesButton : MonoBehaviour
{
    [Header("Target Setting")]
    [SerializeField] private Renderer targetRenderer;
    [SerializeField] private Transform targetScale; // change scale using transform

    [SerializeField] private Material[] presetMaterials;
    [SerializeField] private float[] presetScales;

    [SerializeField] private GameObject vfx;
    [SerializeField] private Transform vfxTF;

    [SerializeField] private UnityEvent onClickButton;

    private Collider _collider;

    private int materialIndex;
    private int scaleIndex;

    private void Start() {
        _collider = GetComponent<Collider>();
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0) && _collider.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 100f))
        {
            if (targetRenderer != null)
            {
                targetRenderer.material = presetMaterials[materialIndex];
                materialIndex++;
                if (materialIndex >= presetMaterials.Length)
                    materialIndex = 0;
            }

            if (targetScale != null)
            {
                targetScale.DOScale(presetScales[scaleIndex], 1.5f);
                scaleIndex++;
                if (scaleIndex >= presetScales.Length)
                    scaleIndex = 0;
            }
            
            GameObject goVfx = GameObject.Instantiate(vfx, vfxTF.position, vfxTF.rotation);
            Destroy(goVfx, 1f);

            onClickButton?.Invoke();
        }
    }
}
